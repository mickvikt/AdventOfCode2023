open Day2
open System.IO

let bag = Combination.create 12 13 14

let lines = File.ReadAllLines "gamedata.txt"

let part1 () =
    let sumOfPossibleGameIds =
        lines
        |> Array.map LineParser.parseGame
        |> Array.filter (fun x -> x |> Game.isPossible bag)
        |> Array.sumBy (fun x -> x.Id)

    printfn "The sum of possible game IDs is: %i" sumOfPossibleGameIds

part1 ()