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
        let res =
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
        res.Sequences