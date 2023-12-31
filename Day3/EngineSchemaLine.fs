namespace Day3

open System

module EngineSchemaLine =
    type private Accumulator = {
        SequenceStartIndex : int
        PreviousIndex : int option
        CurrentSequence : DigitSequence option
        Sequences : DigitSequence list
    }

    let private initialAccumulator =
        { SequenceStartIndex = 0; PreviousIndex = None; CurrentSequence = None; Sequences = [] }


    let getDigitSequences (engineSchema : string array) rowIndex =
        let row = engineSchema[rowIndex]
        let acc =
            row.ToCharArray()
            |> Array.fold
                (fun acc ch ->
                    match Char.IsDigit ch with
                    |true -> match acc.PreviousIndex with
                             | None -> { acc with CurrentSequence = Some (DigitSequence.create rowIndex 0 [ch])
                                                  PreviousIndex = Some 0
                                       }
                             | Some x -> match acc.CurrentSequence with
                                              | None -> { acc with SequenceStartIndex = x + 1
                                                                   PreviousIndex = Some (x + 1)
                                                                   CurrentSequence = Some(DigitSequence.create rowIndex (x + 1) [ch])
                                                        } 
                                              | Some y -> { acc with PreviousIndex = Some (x + 1)
                                                                                     CurrentSequence = Some ({ y with Sequence = y.Sequence @ [ch]} )
                                                                          }
                    |false -> match acc.PreviousIndex with
                              | None -> { acc with PreviousIndex = Some 0 }
                              | Some x ->  match acc.CurrentSequence with
                                                | None -> { acc with PreviousIndex = Some (x + 1) }
                                                | Some y -> { acc with PreviousIndex = Some (x + 1)
                                                                                       Sequences = acc.Sequences @ [y]
                                                                                       CurrentSequence = None
                                                                            })
                initialAccumulator
        match acc.CurrentSequence with
        | None -> acc.Sequences
        | Some x -> match (acc.Sequences |> List.contains x) with
                                   | true -> acc.Sequences
                                   | false -> acc.Sequences @ [x]

    let splitSequenceIndexToColumnIndex (splitSequences : string array) index =
        [0 .. index]
        |> List.map (fun x -> match splitSequences[x].Length with
                                   | 0 -> 1
                                   | y -> y )
        |> List.sum


    let getDigitSequences2 (engineSchema : string array) rowIndex =
        let digitSeparator = '.'
        let row = engineSchema[rowIndex]
        
        let rowWithNonDigitsReplaced =
            row.ToCharArray()
            |> Array.map (fun x -> if Char.IsDigit x then x else digitSeparator)
            |> String
            
        let digitSequences = rowWithNonDigitsReplaced.Split digitSeparator
        digitSequences
        |> Array.map (fun x -> { RowIndex = rowIndex; ColumnIndex = })