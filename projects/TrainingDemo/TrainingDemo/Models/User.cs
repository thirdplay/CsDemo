using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingDemo.Models
{
    /// <summary>
    /// ユーザ情報。
    /// </summary>
    [Table("USER_INFO")]
    public class User
    {
        /// <summary>
        /// ユーザID。
        /// </summary>
        [Display(Name = "ユーザID")]
        [Column("USER_ID")]
        public string UserId { get; set; }

        /// <summary>
        /// パスワード。
        /// </summary>
        [Display(Name = "パスワード")]
        [Column("PASSWORD")]
        public string Password { get; set; }

        /// <summary>
        /// 姓。
        /// </summary>
        [Display(Name = "姓")]
        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        /// <summary>
        /// 名。
        /// </summary>
        [Display(Name = "名")]
        [Column("LAST_NAME")]
        public string LastName { get; set; }

        /// <summary>
        /// 性別。
        /// </summary>
        [Display(Name = "性別")]
        [Column("SEX", TypeName = "char")]
        public string Sex { get; set; }

        /// <summary>
        /// 電話番号。
        /// </summary>
        [Display(Name = "電話番号")]
        [Column("PHONE_NUMBER")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// メールアドレス。
        /// </summary>
        [Display(Name = "メールアドレス")]
        [Column("MAIL_ADDRESS")]
        public string MailAddress { get; set; }
    }
}
