open System

// Общая функция ввода списка целых чисел 
let ReadIntList () =
    printf "Введите список целых чисел через пробел: "
    let input = Console.ReadLine()
    input.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) // Разбивает строку на подстроки 
    |> Array.map int   // Преобразует каждую подстроку в int                                      
    |> List.ofArray     // Преобразует полученный массив чисел в список

// Задание 1 
let FirstDigit (n: int) =  // Поиск первой цифры числа
    let absN  = abs n
    let rec loop x =
        if x < 10 then x
        else loop (x / 10)
    loop absN 

let Searchfirst (numbers: int list) =
    let firstDigits = numbers |> List.map FirstDigit 
    printfn "Исходный список: %A" numbers
    printfn "Список первых цифр: %A" firstDigits

// Задание 2
let counting (numbers: int list) =
    printf "Введите число для подсчёта: "
    let target = Console.ReadLine() |> int
    let count = 
        numbers 
        |> List.fold (fun acc x -> if x = target then acc + 1 else acc) 0  // Использует fold для подсчета повторений (сравнивает все числа с введенным)
    printfn "Число %d встречается %d раз(а)" target count

// Точка входа 
[<EntryPoint>]
let main argv =
    let numbers = ReadIntList ()      
    printfn ""
    Searchfirst numbers                     
    printfn ""
    counting numbers                     
    0
