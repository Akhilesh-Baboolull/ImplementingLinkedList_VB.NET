Module Module1

    Structure node

        Dim data As Integer
        Dim pointer As Integer

    End Structure

    Function IsFull(ByVal freecell As Integer) As Boolean

        If freecell > 8 Then

            IsFull = True
        Else
            IsFull = False

        End If

    End Function

    Function IsEmpty(ByVal head As Integer) As Boolean

        If head = 0 Then
            IsEmpty = True
        Else
            IsEmpty = False
        End If


    End Function

    Sub Insertion(ByRef head As Integer, ByRef freecell As Integer, ParamArray list() As node)

        If IsFull(freecell) = True Then
            Console.WriteLine("The linked list is full")
        Else
            Console.WriteLine("Enter Value: ")
            list(freecell).data = Console.ReadLine()

            If head = 0 Then
                head = freecell
                list(freecell).pointer = 0
            Else

                For i As Integer = 1 To freecell - 1

                    If list(freecell).data > list(i).data And list(i).pointer = 0 Then
                        list(freecell).pointer = 0
                        list(i).pointer = freecell
                    Else

                        If list(freecell).data < list(i).data And i = head Then

                            list(freecell).pointer = i
                            head = freecell

                        Else
                            If list(freecell).data > list(i).data And list(freecell).data < list(list(i).pointer).data Then

                                list(freecell).pointer = list(i).pointer
                                list(i).pointer = freecell

                            End If
                        End If
                    End If

                Next
            End If
            freecell = freecell + 1
        End If

    End Sub
    Sub Main()

        Dim LinkedList(8) As node
        Dim head As Integer
        Dim freecell As Integer
        Dim choice As Integer


        head = 0
        freecell = 1

        Do
            Do
                Console.WriteLine("1...Insertion")
                Console.WriteLine("2...status")
                Console.WriteLine("3...display pointers")
                Console.WriteLine("4...Exit")

                Console.WriteLine("Enter choice:")
                choice = Console.ReadLine()

                If choice < 1 Or choice > 4 Then
                    Console.WriteLine("Invalid choice! Please Re-Enter!")
                End If

                Console.WriteLine()
            Loop Until (choice >= 1 And choice <= 4)

            If choice = 1 Then
                Call Insertion(head, freecell, LinkedList)
            Else
                If choice = 2 Then
                    Console.WriteLine("Is Linked List Full? " & IsFull(freecell))
                    Console.WriteLine("Is Linked List Empty? " & IsEmpty(head))
                Else
                    If choice = 3 Then
                        Console.WriteLine("The Pointers are as follows: ")
                        Console.WriteLine("Head: " & head)
                        Console.WriteLine()
                        For i As Integer = 1 To freecell - 1
                            Console.WriteLine(LinkedList(i).pointer)
                        Next
                    Else
                        Console.WriteLine("You are Exiting the Program!")
                    End If
                End If
            End If
            Console.WriteLine("=====================================================================================")
        Loop Until (choice = 4)




        Console.ReadKey()
    End Sub

End Module
