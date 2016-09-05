// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    let factorial n =
        let rec helper acc n' =
            if n' <= 1 then acc
            else helper (acc * n') (n' - 1)
        helper 1 n

//    let rec factorial n =
//        if n <= 1 then 1
//        else n * (factorial n-1)
//    let rec factorial n =
//        match n with
//        | 0 | 1 -> 1
//        | _ -> n * factorial(n-1)
    let result = factorial 100
    printfn "Hello, %i" result
    0 // return an integer exit code
