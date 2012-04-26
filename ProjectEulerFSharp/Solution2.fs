namespace ProjectEulerFSharp

open System
open System.Numerics
open ProjectEulerCore.Infrastructure

[<Problem(2, "By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.")>]
type Solution2 =
    new() = { }
    
    member private this.max = BigInteger 4000000

    member private this.fibonacci =
        Seq.unfold
            (fun (current, next) -> Some(current, (next, current + next)))
            (BigInteger 0, BigInteger 1)
        
    member this.SolveSimple =
        this.fibonacci
            |> Seq.takeWhile (fun n -> n <= this.max)
            |> Seq.filter (fun n -> (n % BigInteger 2) = BigInteger 0)
            |> Seq.sum

    member this.SolveAddEveryThirdTerm =
        this.fibonacci
            |> Seq.mapi (fun i e -> (i, e))
            |> Seq.takeWhile (fun (i, e) -> e <= this.max)
            |> Seq.filter (fun (i, e) -> i % 3 = 0)
            |> Seq.sumBy (fun (i, e) -> e)

    member this.SolveAddEveryThirdTerm2 =
        // include the term index in the generated Fibonacci sequence to eliminate Seq.mapi
        Seq.unfold
            (fun (i, current, next) -> Some((i, current), (i+1, next, current + next)))
            (0, BigInteger 0, BigInteger 1)
                |> Seq.takeWhile (fun (i, e) -> e <= this.max)
                |> Seq.filter (fun (i, e) -> i % 3 = 0)
                |> Seq.sumBy snd
