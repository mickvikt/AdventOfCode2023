namespace Day3
open PreviousRow

type DigitSequence = {
    RowIndex : int
    ColumnIndex : int
    Sequence : char list
}

module DigitSequence =
    let create rowIndex columnIndex sequence =
        { RowIndex = rowIndex; ColumnIndex = columnIndex; Sequence = sequence}

    let getAdjacentElements (matrix : string array) rowIndex columnIndex  sequence=
        let charArrays = matrix |> Array.map(fun x -> x.ToCharArray())
        let previousRowAdjacent =
            PreviousRow.getAdjacentElements
                charArrays
                rowIndex
                columnIndex
                sequence
        let currentRowAdjacent =
            CurrentRow.getAdjacentElements
                charArrays
                rowIndex
                columnIndex
                sequence
        let nextRowAdjacent =
            NextRow.getAdjacentElements
                charArrays
                rowIndex
                columnIndex
                sequence

        previousRowAdjacent @ currentRowAdjacent @nextRowAdjacent