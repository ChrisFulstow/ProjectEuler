namespace ProjectEulerFSharp

open System
open ProjectEulerCore.Infrastructure

[<Problem(4,
    @"A palindromic number reads the same both ways.
    The largest palindrome made from the product of two 2-digit numbers is 9009 = 91  99.
    Find the largest palindrome made from the product of two 3-digit numbers.")>]
type Solution4() =
    member this.Solve() =
        let products =
            seq {
                for x in { 999 .. -1 .. 100 } do
                for y in { 999 .. -1 .. 100 } do
                if (x < y) then yield x * y }

        let reverse (s:string) = new string(s |> Seq.toArray |> Array.rev)

        products |> Seq.filter (fun x -> string x = reverse(string x)) |> Seq.max
