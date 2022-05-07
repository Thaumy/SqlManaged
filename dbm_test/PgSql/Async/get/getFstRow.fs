module dbm_test.PgSql.Async.get.getFstRow

open NUnit.Framework
open dbm_test.PgSql
open dbm_test.PgSql.Async.init
open fsharper.typ
open fsharper.typ.Ord
open fsharper.op.Boxing
open DbManaged.PgSql.ext.String

[<OneTimeSetUp>]
let OneTimeSetUp () = com.connect ()

[<SetUp>]
let SetUp () = init ()


[<Test>]
let getFstRow_overload1_test () =
    let result =
        com
            .managed
            .unwrap()
            .getFstRow $"SELECT col1,col2 FROM {com.tab1}"
        |> unwrap2

    Assert.AreEqual(0, result.["col1"])
    Assert.AreEqual("i", result.["col2"])



[<Test>]
let getFstRow_overload2_test () =
    let result =
        let paras: (string * obj) list = [ ("col3", "init[050,100]") ]

        com
            .managed
            .unwrap()
            .getFstRow (normalizeSql $"SELECT col1,col2 FROM {com.tab1} WHERE col3 = <col3>", paras)
        |> unwrap2

    Assert.AreEqual(0, result.["col1"])
    Assert.AreEqual("i", result.["col2"])


//overload2 is based on overload3
