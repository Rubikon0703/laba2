open System

// Общая функция ввода списка целых чисел 
let readIntList () =
    printf "Введите список целых чисел через пробел:"
    let input = Console.ReadLine()
    // Разбивает строку на подстроки 
    input.Split([| ' ' |], 
    StringSplitOptions.RemoveEmptyEntries) 
    // Преобразует каждую подстроку в int
    |> Array.map int         
    // Преобразует полученный массив чисел в список
    |> List.ofArray     

// Задание 1 
let firstDigit (n: int) =  // Поиск первой цифры 
    let absN  = abs n
    let rec loop x =
        if 
            x < 10 
        then 
            x
            else loop (x / 10)
    loop absN 

let searchfirst (numbers: int list) =
    let firstDigits = numbers |> List.map firstDigit 
    printfn "Исходный список: %A" numbers
    printfn "Список первых цифр: %A" firstDigits

// Задание 2
let counting (numbers: int list) =
    printf "Введите число для подсчёта: "
    let target = Console.ReadLine() |> int
    let count = 
        numbers 
        |> List.fold (fun acc x -> 
            if 
                x = target 
            then 
                acc + 1 
                else acc) 0  
        // Использует fold для подсчета повторений 
    printfn"%d встречается %d раз(а)"target count

// Точка входа 
[<EntryPoint>]
let main argv =
    let numbers = readIntList ()      
    printfn ""
    searchfirst numbers                     
    printfn ""
    counting numbers                     
    0
