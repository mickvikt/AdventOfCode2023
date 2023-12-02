namespace Day2

module LineParser =
    open System
    open System.Text.RegularExpressions
    open Color
    open ColorAmount

    let parseColorAmount str =
        let pattern = "\s?(\d+)+\s(red|green|blue)"
        let m = Regex.Match(str, pattern)
        let count, colorString = m.Groups[1].Value |> Int32.Parse, m.Groups[2].Value
        let color =
            match colorString with
            | "red" -> Red
            | "green" -> Green
            | "blue" -> Blue
            | _ -> failwith "Bad color value!"
        
        { Color = color; Amount = count }

    let parseCombination (str : string) =
        let cubeCounts = str.Split ','

        let parsedCounts =
            cubeCounts |> Array.map parseColorAmount

        let red = Red |> ColorAmount.getColor parsedCounts
        let green = Green |> ColorAmount.getColor parsedCounts
        let blue = Blue |> ColorAmount.getColor parsedCounts

        Combination.create red green blue

    let parseGameId (str : string) =
        let pattern = "Game (\d+)+"
        let m = Regex.Match (str, pattern)
        let id = m.Groups[1].Value |> Int32.Parse
        id

    let parseGame (line : string) =
        let gameAndCombinations = line.Split ':'
        let id = parseGameId gameAndCombinations[0]

        let combinations = gameAndCombinations[1].Split ';'
        let parsedCombinations =
            combinations
            |> Array.map parseCombination
            |> Array.toList
        
        Game.create id parsedCombinations