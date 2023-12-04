namespace Day3
module PreviousRow =
    let getAdjacentElements (matrix : char array array) rowIndex elementIndex = 
        let previousRow = matrix |> Array.tryItem (rowIndex - 1)
        5