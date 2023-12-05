namespace Day3

module Row =
    let scanRange row range elementIndex =
        let rangeElements =
            range
            |> Array.map (fun x -> Array.tryItem x row)
            |> Array.choose id
        rangeElements

module AdjacentRow =
    open Row

    let scanRange row elementIndex =
        let rangeElements =
            scanRange row [| (elementIndex - 1) ..  (elementIndex + 1) |] elementIndex
        rangeElements

module PreviousRow =
    open AdjacentRow

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex = 
        let previousRow = matrix |> Array.tryItem (rowIndex - 1)
        let adjacentElements =
            previousRow 
            |> Option.map (fun x ->  scanRange x elementIndex)

        adjacentElements

module CurrentRow =
    open Row

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex =
        let currentRow = matrix[rowIndex]
        let indices =
            [elementIndex - 1 ] @ [ elementIndex + 1]
            |> Array.ofList
        let adjacentElements =
            currentRow
            |> Array.map (fun x -> scanRange currentRow indices elementIndex)
        adjacentElements

module NextRow =
    open AdjacentRow

    let getAdjacentElements (matrix : char array array) rowIndex elementIndex = 
        let nextRow = matrix |> Array.tryItem (rowIndex + 1)
        let adjacentElements =
            nextRow 
            |> Option.map (fun x ->  scanRange x elementIndex)

        adjacentElements