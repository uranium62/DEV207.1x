open System
 
let ageCategory name age =
    let category =
        if age >= 20 then "is no longer a teenager"
        elif age >=13 then "is a teenager"
        else "is a kid"
    printfn "%s %s" name category
 
let rec registerNew () =
    printfn "Register new person (Y/N)?"
    match Console.ReadKey().Key with
        | ConsoleKey.Y -> true
        | ConsoleKey.N -> false
        | _ -> registerNew()
 
let rec registerName () =
    printfn "Name: "
    let name = Console.ReadLine()
    if name.Length >= 1
        then name
        else registerName()
 
let rec registerAge() =
    printfn "Age: "
    let success,age = Console.ReadLine()
                        |> System.Int32.TryParse
    if success
        then age
        else registerAge()
   
[<EntryPoint>]
let main argv =
    while registerNew() do
        ageCategory (registerName ()) (registerAge ())
    0