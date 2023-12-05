namespace Day3

module DigitSequence =
    open System

    let getDigitSequences (row : char array) : char array list =
        let separator = '.'
        let digitsWithSeparators =
            row
            |> Array.map (fun x -> if Char.IsDigit x then x else separator)
            |> String
            
        let splitDigits = digitsWithSeparators.Split separator
        let res =
            splitDigits
            |> Array.filter (fun x -> x.Length > 0)
            |> Array.map (fun x -> x.ToCharArray())
            |> Array.toList
        res

    let getAdjacentElements (engineSchema : char array) (digitSequence : char array)
        