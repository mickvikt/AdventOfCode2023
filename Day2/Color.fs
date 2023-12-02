namespace Day2

module Color =
    type Color = |Red |Green |Blue

module ColorAmount =
    open Color

    type ColorAmount = {
        Color: Color
        Amount: int
    }

    let getColor colors color =
        let colorOption =
            colors
            |> Array.filter (fun x -> x.Color = color)
            |> Array.map(fun x -> x.Amount)
            |> Array.tryHead

        match colorOption with
        | Some x -> x
        | None -> 0