let rec dosomethingrandom x =
    if x = 0 then 1
    else dosomethingrandom (x - 1) * x

// 479001600