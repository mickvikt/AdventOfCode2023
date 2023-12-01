open System;
open System.IO;

let getNumbersInLine line =
    line
    |> Seq.filter (fun x -> Char.IsDigit x)
    |> Seq.toArray

let getCalibrationValue line =
    let numbers = line |> getNumbersInLine
    let calibrationValue =
        match numbers |> Array.toList with
        | [x] ->  $"{Array.head numbers}{Array.head numbers}"
        | _::tail -> $"{Array.head numbers}{Array.last numbers}"
        | [] -> failwith "Line contains no digits!"

    calibrationValue |> Int32.Parse


let calibrationLines = File.ReadAllLines "calibrationdocument.txt"

let calibrationValueSum =
    calibrationLines
    |> Array.map getCalibrationValue
    |> Array.sum

printfn "The sum of the calibration values is %i" calibrationValueSum    