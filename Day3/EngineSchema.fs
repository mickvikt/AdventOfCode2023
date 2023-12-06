namespace Day3
open System

module EngineSchema =
    let getPartNumbers (schemaLines : string array) = 
        let res =
            schemaLines
            |> Array.zip [|0 .. schemaLines.Length - 1|]
            |> Array.fold
                     (fun acc indexedLine ->
                        EngineSchemaLine.getDigitSequences 
                            schemaLines 
                            (fst indexedLine)
                        |> List.append acc)
                     []
            |> List.filter (fun x ->
                DigitSequence.getAdjacentElements schemaLines x.RowIndex x.ColumnIndex x.Sequence
                |> List.exists (fun y -> y <> '.' && not (Char.IsDigit y)))
            |> List.map (fun x -> x.Sequence |> List.toArray |> String)
        res