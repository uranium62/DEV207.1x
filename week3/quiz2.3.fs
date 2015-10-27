open System
 
let goldenratio = (1.0 + Math.Sqrt(5.0)) / 2.0
let calcaulateRatio x = x * goldenratio
 
let parseDouble = Double.TryParse >> function
    | true, v -> Some v
    | false, _ -> None
 
let rec readNums() =
    printf "Enter number or anything else to quit: "
    match Console.ReadLine() |> parseDouble with
        | Some d -> d :: readNums()
        | None -> []
 
[<EntryPoint>]
let main argv =
    printfn "The golden ratio calculator!\n"
    let values = readNums()
    let ratios = values |> List.map (fun v -> (v, calcaulateRatio v))
   
    printf "The golden ratios are:\n"
    ratios |> List.iter (fun (value, product) -> printf "(%A, %A)\n" value product)
 
    printf "\nPress any key to quit"
    ignore(Console.ReadKey())
    0