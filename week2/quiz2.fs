open System

let parseInt (str: string) = 
    let mutable value = 0
    if Int32.TryParse(str, &value) then Some(value)
    else None

let parseAge (str: string) =
    let mutable age = 0;
    if Int32.TryParse(str, &age) && age > 0 then Some(age)
    else None

let getPersonState (age: int) = 
    if age >= 20 then "is no longer a teenager"
    elif age <=20 && age > 13 then "is a teenager"
    else "is a kind or child"

let rec renderPersons (n: int) = 
    if n <= 0 then ""
    else
        printfn "Person name: "
        let name = Console.ReadLine()

        if String.IsNullOrEmpty(name) then
            printfn "Wrong name!"
            Environment.Exit(1)
        
        printfn "Person age: "
        let age = parseAge (Console.ReadLine())

        if age.IsNone then
            printfn "Wrong age!"
            Environment.Exit(1)

        String.Format("{0}\t{1}\t{2}\n", name, age.Value, getPersonState(age.Value)) + renderPersons(n-1)


[<EntryPoint>]
let main argv = 
    
    printfn "Persons [n]: "
    let n = parseInt (Console.ReadLine())

    if n.IsNone then
        printfn "Wrong number!"
        Environment.Exit(1)

    printf "%s" (renderPersons n.Value)
    0

