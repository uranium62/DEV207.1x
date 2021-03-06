open System

type MyRecord =
    { IP : string
      MAC : string
      FriendlyName : string
      ID : int }

let IsMatchByName record1 name =
    match record1 with
    | { FriendlyName = nameFound; ID = id; IP = ip } when nameFound = name -> Some((id, ip))
    | _ -> None  

let checkmatch input =
    match input with
    | Some(x, y) -> printfn "%A" x  
    | None       -> printfn "%A" "Sorry no match"  


[<EntryPoint>]
let main argv =

    let r = {
        IP = "10.1.1.1"; 
        MAC = "FF:FF:FF:FF:FF:FF"; 
        FriendlyName = "ServerFailure";
        ID = 0}

    IsMatchByName r "ServerFailure" |> checkmatch

    Console.ReadKey()
    0