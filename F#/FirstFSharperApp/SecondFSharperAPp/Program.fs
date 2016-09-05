// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

type NumberTree =
    | Leaf of int
    | Node of NumberTree * NumberTree

[<EntryPoint>]
let main argv = 
    let rec sumTree tree continues =
        match tree with
        | Leaf(n) -> continues n
        | Node(left, right) ->
            sumTree left (fun leftSum -> 
                sumTree right (fun rightSum -> 
                    continues(leftSum + rightSum)))
    let node1 = Leaf 1
    let node2 = Leaf 2
    let node3 = Leaf 3
    let node4 = Leaf 4
    let tree1 = Node (node1, node2)
    let tree2 = Node (node3, node4)
    let sampleTree = Node (tree1, tree2)
    let result = sumTree sampleTree (fun r -> r)

    printfn "%i" result
    0 // return an integer exit code
