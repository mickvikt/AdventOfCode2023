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