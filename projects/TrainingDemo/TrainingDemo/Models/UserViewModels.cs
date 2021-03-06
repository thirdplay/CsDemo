﻿using System.ComponentModel.DataAnnotations;

namespace TrainingDemo.Models
{
    /// <summary>
    /// ユーザ情報一覧画面のViewModel。
    /// </summary>
    public class UserIndexViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Display(Name = "姓")]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Display(Name = "名")]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Display(Name = "性別")]
        public string Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [Display(Name = "電話番号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [Display(Name = "メールアドレス")]
        public string MailAddress { get; set; }
    }

    /// <summary>
    /// ユーザ情報編集画面のViewModel。
    /// </summary>
    public class UserEditViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        [Display(Name = "パスワード")]
        public string Password { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Display(Name = "姓")]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Display(Name = "名")]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Display(Name = "性別")]
        public Sex? Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [Display(Name = "電話番号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [Display(Name = "メールアドレス")]
        public string MailAddress { get; set; }
    }

    /// <summary>
    /// ユーザ情報削除画面のViewModel。
    /// </summary>
    public class UserDeleteViewModel
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Display(Name = "ユーザID")]
        public string UserId { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Display(Name = "姓")]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Display(Name = "名")]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Display(Name = "性別")]
        public string Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [Display(Name = "電話番号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [Display(Name = "メールアドレス")]
        public string MailAddress { get; set; }
    }
}