open System

let goldenratio = (1.0 + Math.Sqrt(5.0)) / 2.0

let GetRatio value  = 
    (value, float value * goldenratio) 

[<EntryPoint>]
let main argv = 

    let ratios =
        [ let mutable run = true
          while run do
              printfn "Do you want to add value (y/n)? "
              if Console.ReadLine().ToLower() = "y" then   
                            
                  printfn "Enter value: "
                  let success, value = Console.ReadLine() |> Double.TryParse

                  if success then yield GetRatio value
                  else printfn "Wrong value!"

              else run <- false ]

    for ratio in ratios do
        let value, xratio = ratio
        printfn "%f %f" value xratio
    
    Console.ReadKey()
    0 