// experimentation

open System
open System.Numerics

let reverse (s:string) = new string(Array.rev(s.ToCharArray()))
let palindromes =
    seq { 997 .. -1 .. 1 } 
    |> Seq.map (fun n -> Int32.Parse(n.ToString() + reverse(n.ToString())))

let products =
    seq {
        for x in { 999 .. -1 .. 100 } do
        for y in { 999 .. -1 .. 100 } do
        yield (x, y) }

palindromes |> Seq.find (fun x -> products |>  Seq.exists (fun n -> n = x))
// Seq.filter (fun y -> y > x) |>


products

//        private static bool IsProductOfTwo3DigitNumbers(int num)
//        {
//            for (var i = 999; i >= 100; i--)
//            {
//                for (var j = 999; j >= 100; j--)
//                {
//                    var product = i * j;
//                    if (product < num) break;
//                    if (product != num) continue;
//                    return true;
//                }
//            }
//            return false;
//        }