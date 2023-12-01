open System;
open System.IO;

// Digit index inside a string
type DigitIndex = {
    digit: int
    index: int
}

let numbersAsWords =
    Map [("one", 1)
         ("two", 2)
         ("three", 3)
         ("four", 4)
         ("five", 5)
         ("six", 6)
         ("seven", 7)
         ("eight", 8)
         ("nine", 9)
    ]

let findAllIndices (substr : string) (str : string) =
    str
    |> Seq.windowed substr.Length
    |> Seq.mapi (fun i window -> if String(window) = substr then Some i else None)
    |> Seq.choose id
    |> Seq.toList

let getDigitIndices numAsString num str =
    str
    |> findAllIndices numAsString
    |> List.map (fun x -> { digit = num; index = x })
    |> List.distinct

let getSpelledOutNumbersIndices (line : string) =
    numbersAsWords
    |> Seq.fold (fun acc numAsString ->
                 match line.Contains numAsString.Key with
                 | true -> line
                           |> getDigitIndices numAsString.Key numAsString.Value
                           |> List.append acc
                 | false -> acc)
                 []

let getNumbersIndices (line : string) =
    line
    |> Seq.filter Char.IsDigit
    |> Seq.map (fun x -> x |> string)
    |> Seq.collect(fun x -> (getDigitIndices x  (x |> Int32.Parse) line))
    |> Seq.distinct
    |> Seq.toList


let getCalibrationValue line = 
    let indices =
        getNumbersIndices line
        |> List.append (getSpelledOutNumbersIndices line)
        |> List.sortBy (fun x -> x.index)

    let calibrationValue =
        match indices with
        | [x] ->  $"{x.digit}{x.digit}"
        | head::tail -> $"{head.digit}{(List.last tail).digit}"
        | [] -> failwith $"Line contains no digits: {line}!"

    calibrationValue |> Int32.Parse


let calibrationLines = File.ReadAllLines "calibrationdocument.txt"
let calibrationValueSum =
    calibrationLines
    |> Array.map getCalibrationValue
    |> Array.sum

printfn "The sum of the calibration values is %i" calibrationValueSum