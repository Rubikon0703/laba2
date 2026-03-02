open System

//Общая функция ввода списка целых чисел 
let readIntList () =
    printf "Введите список целых чисел через пробел: "
    let input = Console.ReadLine()
    input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)//разбивает строку на подстроки 
    |> Array.map int   //преобразованует каждую подстроку в int                                      
    |> List.ofArray     //Преобразует полученный массив чисел в список

//Задание 1 
let firstDigit (n: int) = //поиск первой цифры числа
    let absN  = abs n
    let rec loop x =
        if x < 10 then x
        else loop (x / 10)
    loop absN 

let task1 (numbers: int list) =
    let firstDigits = numbers |> List.map firstDigit 
    printfn "Исходный список: %A" numbers
    printfn "Список первых цифр: %A" firstDigits

//Задание 2
let task2 (numbers: int list) =
    printf "Введите число для подсчёта: "
    let target = Console.ReadLine() |> int
    let count = 
        numbers 
        |> List.fold (fun acc x -> if x = target then acc + 1 else acc) 0//использует fold для подсчета повторений (сравнивает все числа с введенным)
    printfn "Число %d встречается %d раз(а)" target count

//Точка входа 
[<EntryPoint>]
let main argv =
    let numbers = readIntList ()      
    printfn ""
    task1 numbers                     
    printfn ""
    task2 numbers                     
    0