﻿using System;
using System.IO;
using System.Reactive.Disposables;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Prototype.Mvc.Interop
{
	/// <summary>
	/// Interop.Excelアプリケーションを操作する機能を提供します。
	/// </summary>
	public class InteropExcel : IDisposable
	{
		#region Fields

		/// <summary>
		/// ファイルパスを取得します。
		/// </summary>
		private string filePath;

		/// <summary>
		/// ファイル名を取得します。
		/// </summary>
		private string fileName;

		/// <summary>
		/// Excelアプリケーション
		/// </summary>
		private Excel.Application application;

		/// <summary>
		/// ワークブックス
		/// </summary>
		private Excel.Workbooks workbooks;

		/// <summary>
		/// ワークブック
		/// </summary>
		private Excel.Workbook workbook;

		/// <summary>
		/// ワークシート
		/// </summary>
		private Excel.Sheets sheets;

		#endregion Fields

		/// <summary>
		/// 複数のIDisposableオブジェクトをまとめたコレクション
		/// </summary>
		public CompositeDisposable CompositeDisposable { get; } = new CompositeDisposable();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="filePath">Excelファイルのパス</param>
		public InteropExcel(string filePath)
		{
			this.filePath = filePath;
			this.fileName = Path.GetFileName(filePath);

			this.application = new Excel.Application().AddTo(this);
			this.application.DisplayAlerts = false;
			this.application.Visible = false;
			this.workbooks = this.application.Workbooks.AddTo(this);
			this.workbook = this.workbooks.Open(this.filePath).AddTo(this);
			this.sheets = this.workbook.Worksheets.AddTo(this);
		}

		/// <summary>
		/// マクロの実行、または関数の呼び出しを行います。
		/// </summary>
		/// <param name="macroName">実行するマクロ名</param>
		/// <param name="args">実行引数</param>
		/// <example>
		/// Run("This.Workbook.TestMacro"); // ワークブックのマクロ呼び出し Run("Sheet1.TestMacro");// シートのマクロ呼び出し
		/// Run("TestMacro");// 標準モジュールのマクロ呼び出し
		/// </example>
		public void Run(string macroName, params object[] args)
		{
			var macro = $"{this.fileName}!{macroName}";
			var method = this.application.GetType().GetMethod("Run");

			switch (args.Length)
			{
				case 0: this.application.Run(macro); break;
				case 1: this.application.Run(macro, args[0]); break;
				case 2: this.application.Run(macro, args[0], args[1]); break;
				case 3: this.application.Run(macro, args[0], args[1], args[2]); break;
				case 4: this.application.Run(macro, args[0], args[1], args[2], args[3]); break;
				case 5: this.application.Run(macro, args[0], args[1], args[2], args[3], args[4]); break;
				case 6: this.application.Run(macro, args[0], args[1], args[2], args[3], args[4], args[5]); break;
				case 7: this.application.Run(macro, args[0], args[1], args[2], args[3], args[4], args[5], args[6]); break;
				case 8: this.application.Run(macro, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]); break;
				case 9: this.application.Run(macro, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8]); break;
			}
		}

		/// <summary>
		/// ブックの変更を別のファイルに保存します。
		/// </summary>
		/// <param name="fileName">保存するファイルの名前</param>
		public void SaveAs(string fileName)
		{
			this.workbook.SaveAs(fileName);
		}

		/// <summary>
		/// このインスタンスによって使用されているリソースを全て破棄します。
		/// </summary>
		public void Dispose()
		{
			this.workbooks.Close();
			this.application.Quit();
			this.CompositeDisposable.Dispose();
		}
	}

	/// <summary>
	/// Interop.Excelの拡張機能を提供します。
	/// </summary>
	public static class InteropExcelExtensions
	{
		/// <summary>
		/// ComObjectの後処理を登録します。
		/// </summary>
		/// <typeparam name="T">ComObjectの任意のクラス</typeparam>
		/// <param name="dispose">登録するComObject</param>
		/// <param name="interopExcel">Interop.Excelのインスタンス</param>
		/// <returns>登録するComObject</returns>
		public static T AddTo<T>(this T dispose, InteropExcel interopExcel)
		{
			if (interopExcel == null)
			{
				throw new ArgumentNullException(nameof(interopExcel));
			}

			interopExcel.CompositeDisposable.Add(
				Disposable.Create(() => Marshal.FinalReleaseComObject(dispose)));

			return dispose;
		}
	}
}
