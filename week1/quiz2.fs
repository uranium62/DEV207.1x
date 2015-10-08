open System

let cylinder (r: float) (h: float) = Math.PI * Math.Pow(r, 2.0) * h

[<EntryPoint>]
let main argv = 

Console.Write("H: ")
let h = float (Console.ReadLine())

Console.Write("R: ")
let r = float (Console.ReadLine())

printfn "%f" (cylinder r h)
Console.ReadKey()
0