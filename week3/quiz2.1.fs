let arr = [| 1; 2; 3; 4; 5; 6; 7; 8; 9 |]
let l = arr.Length

let out =
    [ for i = 0 to l do
          if isEven arr.[i] then arr.[i] ]

let newout = 0 @ out