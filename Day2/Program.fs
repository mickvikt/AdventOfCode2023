open Day2
open Combination
open System.IO

let bag = Combination.create 12 13 14

let lines = File.ReadAllLines "gamedata.txt"

let part1 lines =
    let sumOfPossibleGameIds =
        lines
        |> Array.map LineParser.parseGame
        |> Array.filter (fun x -> x |> Game.isPossible bag)
        |> Array.sumBy (fun x -> x.Id)

    printfn "Part 1. The sum of possible game IDs is: %i" sumOfPossibleGameIds

let part2 line =
    let sumOfPowers =
        lines
        |> Array.map LineParser.parseGame
        |> Array.map Game.getMinAmountsForPlayableGame
        |> Array.map Combination.power
        |> Array.sum

    printfn "Part 1. The sum of powers of minimal sets is: %i" sumOfPowers


part1 lines
part2 lines
