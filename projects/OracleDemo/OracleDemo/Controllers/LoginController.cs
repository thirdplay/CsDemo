﻿using OracleDemo.Models;
using OracleDemo.Services;
using System;
using System.Web.Mvc;

namespace OracleDemo.Controllers
{
    /// <summary>
    /// ログイン画面を制御するクラスです。
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// ユーザの業務ロジック。
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="service">ユーザの業務ロジック</param>
        public LoginController(IUserService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ログイン処理。
        /// </summary>
        /// <param name="model">ログイン画面のViewModel</param>
        /// <returns>アクションの結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                // ログインユーザのチェック
                User condition = new User()
                {
                    UserId = model.UserId,
                    Password = model.Password
                };
                this._service.Exists(condition);

                // 認証OK
                return RedirectToAction("Index", "User");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
    }
}