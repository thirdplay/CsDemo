﻿using Prototype.Resources;
using System;
using System.Web.Mvc;

namespace Prototype.Utilities.Validations
{
    /// <summary>
    /// プロパティで許容される最小文字数を指定します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinLengthAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        /// <summary>
        /// 許容される最小文字数を取得します。
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="length">許容される最小文字数</param>
        public MinLengthAttribute(int length) : base()
        {
            this.Length = length;
        }

        /// <summary>
        /// 指定したエラーメッセージに書式を適用します
        /// </summary>
        /// <param name="name">書式設定された文字列に含まれる名前</param>
        /// <returns>許容される最小文字数を説明する文字列</returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.Length);
        }

        /// <summary>
        /// プロパティが最小文字数未満でないことを確認します。
        /// </summary>
        /// <param name="value">検証するプロパティの値</param>
        /// <returns>検証が成功した場合はtrue、それ以外の場合はfalse</returns>
        public override bool IsValid(object value)
        {
            var length = 0;

            if (value == null)
            {
                return true;
            }
            else
            {
                if (value is string)
                {
                    length = (value as string).Length;
                }
                else if (value is Array)
                {
                    length = (value as Array).Length;
                }
            }
            return length >= this.Length;
        }
    }

    /// <summary>
    /// 最小文字数属性のアダプタを提供します。
    /// </summary>
    public class MinLengthAttributeAdapter : DataAnnotationsModelValidator<MinLengthAttribute>
    {
        public MinLengthAttributeAdapter(ModelMetadata metadata, ControllerContext context, MinLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Messages);
            attribute.ErrorMessageResourceName = "MS002";
            attribute.ErrorMessage = null;
        }
    }
}