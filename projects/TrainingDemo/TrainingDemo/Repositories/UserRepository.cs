﻿using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using TrainingDemo.Models;

namespace TrainingDemo.Repositories
{
    /// <summary>
    /// ユーザ情報のリポジトリインターフェイス。
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 指定されたユーザIDを持つユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        User Find(string userId);

        /// <summary>
        /// すべてのユーザ情報を取得します。
        /// </summary>
        /// <returns>ユーザ情報リスト</returns>
        List<User> ListAll();
    }

    /// <summary>
    /// ユーザ情報のリポジトリクラス。
    /// </summary>
    /// <remarks>
    /// Select文を発行するには、Queryメソッドを利用します。
    /// またDMLを発行するには、Executeメソッドを利用します。
    /// 第二引数のparamは、パラメータとして展開するクラスのインスタンスを指定します。
    /// 下記の例では、SQLにタグ内の抽出条件が追加されます。
    /// :…には第二引数のparamで指定したクラスのプロパティ名を指定します。
    /// </remarks>
    /// <example>
    /// ■Insert文の例
    /// this.Execute(@"INSERT INTO USER_INFO VALUES(:UserId, :Password, …)", user);
    /// 
    /// ■Update文の例
    /// this.Execute(@"UPDATE USER_INFO SET USER_ID = :UserId, PASSWORD = :Password, … WHERE USER_ID = :UserId", user);
    /// </example>
    public class UserRepository : RepositoryBase, IUserRepository
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="dbConnection">データベースへの接続</param>
        public UserRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        /// <summary>
        /// 指定されたユーザIDを持つユーザ情報を検索します。
        /// </summary>
        /// <param name="userId">ユーザID</param>
        /// <returns>ユーザ情報</returns>
        public User Find(string userId)
        {
            return this.Query<User>(
                @"SELECT * FROM USER_INFO WHERE USER_ID = :UserId",
                new { UserId = userId }
            ).FirstOrDefault();
        }

        /// <summary>
        /// すべてのユーザ情報を取得します。
        /// </summary>
        /// <returns>ユーザ情報リスト</returns>
        public List<User> ListAll()
        {
            return this.Query<User>(@"SELECT * FROM USER_INFO").ToList();
        }
    }
}