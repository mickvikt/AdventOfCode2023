open Day3
open System
open System.IO

let engineSchema = File.ReadAllLines "engineSchema.txt"

let part1 engineSchema =
    let sumOfPartNumbers =
        EngineSchema.getPartNumbers engineSchema
        |> List.map Int32.Parse
        |> List.sum

    printfn "Answer to Part 1. The sum of part numbers is %i" sumOfPartNumbers

part1 engineSchema