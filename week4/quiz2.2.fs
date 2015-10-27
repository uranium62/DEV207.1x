open System
open System.IO
 
 
let gravity = 9.81
 
let sqr x =
    x * x
 
let angle_of_reach distance speed =
    0.5 * Math.Asin(gravity * distance / sqr speed)
 
let distance_travelled speed angle =
    sqr speed * Math.Sin(2.0 * angle) / gravity
 
let angle x y =
    Math.Atan(y/x)
 
type Gun =
    { TargetX           : double;
      TargetY           : double;
      Speed             : double;
      ExpectedDistance  : double;
      Name              : string;
    }
 
let classify gun =
    let a = angle gun.TargetX gun.TargetY
    let d = distance_travelled gun.Speed a
    if gun.ExpectedDistance = d then
        printfn "%A hits the target" gun.Name
    else
        printfn "%A misses the target, angle required %A " gun.Name (angle_of_reach gun.ExpectedDistance gun.Speed)
 
 
[<EntryPoint>]
let main argv =
    try
        use input =
            new StreamReader(match argv.Length with
                             | 0 -> Console.Write("Enter the full path to the Name of the input file: ")
                                    Console.ReadLine()    
                             | _ -> argv.[0])    
 
        let guns =
            [ while not input.EndOfStream do
                  let raw = input.ReadLine()
                  let values = raw.Split(',')
                  yield { TargetX = double values.[0]
                          TargetY = double values.[1]
                          Speed = double values.[2]
                          ExpectedDistance = double values.[3]
                          Name = values.[4] } ]
 
        Console.WriteLine("The gun classification is: ")
        for gun in guns do
            classify gun
 
        Console.ReadKey() |> ignore
        0
    with
    | :? System.IO.FileNotFoundException ->
        Console.Write("File Not Found. Press a key to exit")
        Console.ReadKey() |> ignore
        -1
    | _ ->
        Console.Write("Something else happened")
        Console.ReadKey() |> ignore
        -1