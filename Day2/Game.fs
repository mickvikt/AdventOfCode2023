namespace Day2
module Combination =
    type Combination = {
        Red: int
        Green: int
        Blue: int
    }

    let create red green blue =
        { Red = red; Green = green; Blue = blue }

    let isPossible bag combination =
        combination.Red <= bag.Red &&
        combination.Green <= bag.Green &&
        combination.Blue <= bag.Blue

    let power combination =
        combination.Red * combination.Green * combination.Blue

module Game =
    open Combination

    type Game = {
        Id : int
        Draws: Combination list
    }

    let create id draws =
        { Id = id; Draws = draws }

    let isPossible bag game =
        game.Draws
        |> List.forall (fun draw -> draw |> Combination.isPossible bag)

    let getMinAmountsForPlayableGame game =
        let minRed =
            game.Draws
            |> List.map(fun x -> x.Red)
            |> List.max
            
        let minGreen =
            game.Draws
            |> List.map(fun x -> x.Green)
            |> List.max

        let minBlue =
            game.Draws
            |> List.map(fun x -> x.Blue)
            |> List.max

        Combination.create minRed minGreen minBlue
        