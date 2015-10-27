open System
open System.IO
 
type Gun = {
    x: float
    y: float
    speed: float
    expectedDistance: float
    name: string
}
 
 
let GRAVITY = 9.81
let EPS     = 0.00001
 
 
let angleOfReach distance speed gravity =
    let angle = 0.5 * Math.Asin(gravity * distance / Math.Pow(speed, 2.0))
    if not (Double.IsNaN angle) then Some(angle)
    else None
 
 
let distanceTravelled speed angle =
    (Math.Pow(speed, 2.0) * Math.Sin(2.0 * angle)) / GRAVITY
 
 
let calculateAngle x y =
    Math.Atan(y/x)
 
 
let howFar x y speed =
    distanceTravelled speed (calculateAngle x y)
 
 
let willHit x y speed expectedDistance =
    Math.Abs((howFar x y speed) - expectedDistance) < EPS
 
 
let (|Hit|Miss|Invalid|) input =
    match input with
    | { x = a; y = b; speed = c; expectedDistance = d; name = e; } when a > 0.0 && willHit a b c d -> Hit
    | { x = a; y = b; speed = c; expectedDistance = d; name = e; } when a > 0.0 && not (willHit a b c d) -> Miss
    | _ -> Invalid
 
 
let GetFile =
    Console.Write("Enter the full path to the name of the input file: ")
    Console.ReadLine()
 
 
[<EntryPoint>]    
let main argv =
    try
        use input =
            new StreamReader(match argv.Length with
                             | 0 -> GetFile    
                             | _ -> argv.[0])    
 
        let guns =
            [ while not input.EndOfStream do
                  let raw = input.ReadLine()
                  let values = raw.Split(',')
                  yield { x = float values.[0]
                          y = float values.[1]
                          speed = float values.[2]
                          expectedDistance = float values.[3]
                          name = values.[4] } ]
 
        for g in guns do
            match g with
            | Hit  -> printfn "Gun %A hit!" g.name
            | Miss ->
                let angle = angleOfReach g.expectedDistance g.speed GRAVITY
                match angle with
                | Some(x) -> printfn "Gun %A didn't hit. Adjust angle to %f" g.name x
                | None -> printfn "Gun %A didn't hit. Angle adjustment failed" g.name
            | Invalid -> printfn "Invalid data"
 
        ignore(Console.ReadKey())
        0
 
    with
    | :? System.IO.FileNotFoundException ->
        Console.Write("File Not Found. Press a key to exit")
        ignore(Console.ReadKey())
        -1
    | _ ->
        Console.Write("Something else happened")
        ignore(Console.ReadKey())
        -1