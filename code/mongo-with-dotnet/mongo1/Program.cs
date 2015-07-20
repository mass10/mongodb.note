using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Shared;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Core.Connections;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Linq.Utils;
using Newtonsoft.Json;

namespace mongo1
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("### start ###");
				Test01().Wait();
				Console.WriteLine("--- end ---");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private async static Task Test01()
		{
			//
			// この静的メソッドは async です。呼び出し側で Wait() しなければ実行されません。
			//

			// MongoDB との接続を確立します。
			IMongoClient session = new MongoClient("mongodb://192.168.141.128:27017");
			
			// テータベース [test] に切り替えています。
			IMongoDatabase database = session.GetDatabase("test");

			// 酒蔵コレクションを参照しています。
			IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("sakaguradb");

			// ================================================================
			// データを抽出しています。
			// ================================================================

			if(true)
			{
				Console.WriteLine();
				Console.WriteLine("#");
				Console.WriteLine("# その1");
				Console.WriteLine("#");
				Console.WriteLine();

				var watch = new System.Diagnostics.Stopwatch();
				watch.Start();

				Console.WriteLine("抽出処理(その1): BEGIN");
				using (var cursor = await collection.Find(new BsonDocument()).ToCursorAsync())
				{
					while (await cursor.MoveNextAsync())
					{
						foreach (var e in cursor.Current)
						{
							e.Remove("_id");
							string s = e.ToJson();
							s = Util.FormatJson(s);
							Console.WriteLine(s);
						}
					}
				}
				Console.WriteLine("抽出処理(その1): END (処理時間={0})", watch.Elapsed);
			}

			if(true)
			{
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("#");
				Console.WriteLine("# 件数を抽出");
				Console.WriteLine("#");
				Console.WriteLine();

				var watch = new System.Diagnostics.Stopwatch();
				watch.Start();

				var count = await collection.CountAsync(new BsonDocument());
				Console.WriteLine("件数: " + count + " (処理時間=" + watch.Elapsed + ")");
			}

			if (true)
			{
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("#");
				Console.WriteLine("# 抽出処理(その2)");
				Console.WriteLine("#");
				Console.WriteLine();
				Console.WriteLine("抽出処理(その2): BEGIN");

				var watch = new System.Diagnostics.Stopwatch();
				watch.Start();

				var result = await collection.FindAsync<BsonDocument>(new BsonDocument());
				var list = await result.ToListAsync<BsonDocument>();
				foreach (var e in list)
				{
					e.Remove("_id");
					string s = e.ToJson();
					s = Util.FormatJson(s);
					Console.WriteLine(s);
				}

				Console.WriteLine("抽出処理(その2): END (処理時間=" + watch.Elapsed + ")");
			}
		}

	}
}