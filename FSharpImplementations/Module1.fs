// Learn more about F# at http://fsharp.net

module Module1

let addSpaces (data:string) =
   let addStateToList state list =
       match state with
       | 0 -> list
       | 1 -> '\r'::list
       | 2 -> '\n'::'\r'::list
       | 3 -> '\r'::'\n'::'\r'::list
       | _ -> failwith "invalid"

   let list,state=  
       data
       |> Seq.fold ( fun (l,state) cur ->  
           match state,cur with
           | 0,'\r' -> (l,1)
           | 1,'\n' -> (l,2)
           | 2,'\r' -> (l,3)
           | 3,'\n' -> (' '::'\n'::'\r'::l,2)
           | _ -> (cur :: (l |> addStateToList state), 0)) (List.empty,0)

   let list = addStateToList state list

   let arr = list |> List.rev |> Array.ofList

   new System.String(arr)