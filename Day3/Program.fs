open Day3
open System
open System.IO

let engineSchema = File.ReadAllLines "engineSchema.txt"
//let x = EngineSchema.getPartNumbers engineSchema


let x = DigitSequence.getAdjacentElements engineSchema 2 2 ['3';'5']
 
let charArrays = engineSchema |> Array.map(fun x -> x.ToCharArray())
// let y = Row.scanRange charArrays[0] [| -1; 4 |] 0

// let y = CurrentRow.getAdjacentElements charArrays 0 5 ['1';'1';'4']
printfn "%A" x