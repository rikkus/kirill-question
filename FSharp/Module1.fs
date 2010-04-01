module FS
#light

module JaredParsons =

    let InsertSpaceBetweenCrLfs (input:string) =
       
       let addStateToList state list =
           match state with
           | 0 -> list
           | 1 -> '\r'::list
           | 2 -> '\n'::'\r'::list
           | 3 -> '\r'::'\n'::'\r'::list
           | _ -> failwith "invalid"

       let list,state=  
           input
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
       
open System

module SebastianU =

   let InsertSpaceBetweenCrLfs (input:string) =
   
        input.Split([| Environment.NewLine |], StringSplitOptions.None)
            |> Seq.map (function "" -> " " | s -> s)
            |> String.concat Environment.NewLine
            
            
module fholm =
  let split (str:string) = 
    let length = str.Length
    let mutable sb = new System.Text.StringBuilder()
    let mutable pos = 0
    let mutable state = 0

    while pos < length do
      
      //do
      match state with
        // "" and \r\n
        | 0 | 2 ->
          if str.[pos] = '\r' then
            state <- state + 1
          else
            if state > 0 then
              sb <- sb.Append("\r\n") 

            sb.Append(str.[pos])
            state <- 0

        // \r
        | 1 ->
          if str.[pos] = '\n' then
            state <- 2
          else
            sb.Append('\r').Append(str.[pos])
            state <- 0

        // \r\n\r
        | 3 -> 
          if str.[pos] = '\n' then
            sb.Append("\r\n ")
            state <- 2
          else
            sb.Append("\r\n\r").Append(str.[pos])
            state <- 0
        | _ -> failwith "should not happen"

      //next
      pos <- pos + 1

    (match state with
    | 1 -> sb.Append('\r')
    | 2 -> sb.Append("\r\n")
    | 3 -> sb.Append("\r\n\r")
    | _ -> sb).ToString()
          
module warturtle =
    let fix (s:string) = 

        let guides = new ResizeArray<int*int*int>()

        let rec lookForReturnCar startPos endPos sRsNAcc nested wsBuffer = if (startPos+1 < s.Length) && (endPos+1 < s.Length) then
                                                                                match (s.[endPos],s.[endPos+1]) with
                                                                                | ('\\','r')                -> lookForNextLine startPos (endPos+2) sRsNAcc
                                                                                | (' ',_) when nested = true -> lookForReturnCar startPos (endPos+1) sRsNAcc true (wsBuffer+1)
                                                                                | (' ',_) when nested = false -> lookForReturnCar (startPos+1) (endPos+1) sRsNAcc false 0
                                                                                | ('\\','t') when nested = true -> lookForReturnCar startPos (endPos+2) sRsNAcc true (wsBuffer+2)
                                                                                | ('\\','t') when nested = false -> lookForReturnCar (startPos+2) (endPos+2) sRsNAcc false 0
                                                                                |  (_,_)  when sRsNAcc > 1    -> guides.Add(startPos, (endPos-wsBuffer), sRsNAcc); lookForReturnCar (endPos+1) (endPos+1) 0 false 0
                                                                                |  (_,_) when sRsNAcc < 2    -> lookForReturnCar (endPos+1) (endPos+1) 0 false 0
                                                                                |  _                        -> failwithf "oops"
                                                                           else if sRsNAcc > 1 then guides.Add(startPos, endPos, sRsNAcc) else ()

        and lookForNextLine startPos endPos sRsNAcc = if (startPos+1 < s.Length) && (endPos < s.Length) then
                                                                 match (s.[endPos],s.[endPos+1]) with
                                                                 | ('\\','n')                -> lookForReturnCar startPos (endPos+2) (sRsNAcc+1) true 0
                                                                 | (' ',_)                  -> lookForNextLine startPos (endPos+1) sRsNAcc
                                                                 | ('\\','t')                -> lookForNextLine startPos (endPos+2) sRsNAcc
                                                                 | ( _ ,_ )   when sRsNAcc > 1     -> guides.Add(startPos, endPos, sRsNAcc); lookForReturnCar (endPos) (endPos) 0 false 0
                                                                 | ( _ , _ )  when sRsNAcc < 2     -> lookForReturnCar endPos endPos 0 false 0
                                                                 |  _                       -> failwithf "oops"
                                                       else if sRsNAcc > 1 then guides.Add(startPos, endPos, sRsNAcc) else ()

        lookForReturnCar 0 0 0 false 0

        let buf = new System.Text.StringBuilder()

        let finalForm = new ResizeArray<int>()

        finalForm.Add(0)

        for (startn, endingn, sRsNnum) in guides do
            finalForm.Add(startn)
            finalForm.Add(sRsNnum)
            finalForm.Add(endingn)

        finalForm.Add(s.Length)

        for i in 0 .. 3 .. (finalForm.Count-3) do
            buf.Append(s.Substring(finalForm.[i], finalForm.[i+1] - finalForm.[i]))|>ignore
            for j = 2 to finalForm.[i+2] do
                buf.Append("\r\n ")|>ignore
            buf.Append("\r\n")|>ignore    

        buf.Append(s.Substring(finalForm.[finalForm.Count-2], finalForm.[finalForm.Count-1] - finalForm.[finalForm.Count-2]))|>ignore

        buf.ToString()