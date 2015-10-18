open System
 
let parseInt s =
    let success, i = Int32.TryParse(s)
    if success then i else -1
 
let readInt message failureMessage =
    let mutable integer = -1
    printf message
    integer <- parseInt (Console.ReadLine())
    while integer = -1 do
        printf failureMessage
        integer <- parseInt (Console.ReadLine())
    integer
 
let classify age =
    if age >= 20 then
        "is no longer a teenager"
    elif age > 13 && age < 20 then
        "is a teenager"
    else
        "is a child"
 
 
[<EntryPoint>]
let main argv =
    let count = readInt "How many people you want to classify? "  "How many people did you say? "
    for i = 1 to count do
        printf "Enter name: "
        let name = Console.ReadLine()
        let age = readInt "Enter age: " "please enter integer"
        let message = classify age
        printf "%s %d %s\n" name age message
 
    ignore (Console.ReadKey())
    0