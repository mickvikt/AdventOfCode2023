open System
open System.IO


let getPreviousRow (matrix : string array) elementIndex =
    let row =
        match elementIndex with
        | 0 -> None
        | _ -> Some (matrix[elementIndex - 1])
    row

let getAdjacentElements (row : char array) (digitSequence : char array) elementIndex =
    let elementToTheLeft = Array.tryItem (elementIndex - 1) row
    let elementToTheRight =
        Array.tryItem (elementIndex + digitSequence.Length) row

    [elementToTheLeft; elementToTheRight]
    |> List.choose id


let engineSchema = File.ReadAllLines

open System
open Day3
let testLine = "...567....89.1...19."
let x = DigitSequence.getDigitSequences (testLine.ToCharArray())
printfn "%A" x