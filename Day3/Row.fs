namespace Day3

module Row =
    let scanRange row range elementIndex =
        let rangeElements =
            range
            |> Array.map (fun x -> Array.tryItem x row)
            |> Array.choose id
            |> Array.toList
        rangeElements

module AdjacentRow =
    open Row

    let scanRange row elementIndex (sequence : char list) =
        let rangeElements =
            scanRange row [| (elementIndex - 1) ..  (elementIndex + sequence.Length) |] elementIndex
        rangeElements

module PreviousRow =
    open AdjacentRow

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex (sequence : char list) = 
        let previousRow = matrix |> Array.tryItem (rowIndex - 1)
        let adjacentElements =
            previousRow 
            |> Option.map (fun x ->  scanRange x elementIndex sequence)

        match adjacentElements with
        | None -> []
        | Some x -> x

module CurrentRow =
    open Row

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex (sequence : char list) =
        let currentRow = matrix[rowIndex]
        let elementToTheLeft = currentRow |> Array.tryItem (elementIndex - 1)
        let elementToTheRight = currentRow |> Array.tryItem (elementIndex + sequence.Length)
        let elements = [elementToTheLeft; elementToTheRight]

        let adjacentElements =
            elements |> List.choose id

        adjacentElements

module NextRow =
    open AdjacentRow

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex (sequence : char list) = 
        let nextRow = matrix |> Array.tryItem (rowIndex + 1)
        let adjacentElements =
            nextRow 
            |> Option.map (fun x ->  scanRange x elementIndex sequence)

        match adjacentElements with
        | None -> []
        | Some x -> x