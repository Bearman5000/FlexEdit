﻿Public Class MainForm
    Public i As Integer = 0
    Public mySplashScreen = DirectCast(My.Application.SplashScreen, Splash)

    'States that will be controlled by checkboxes
    Public saveword2enabled As Boolean = False
    Public saveword3enabled As Boolean = False

    'Checks whether user has accepted the agreement for raw edits (prompt)
    Dim AcceptedRawTerms As Boolean = False

    'Load saveword form vars
    Public SavewordText1 As String
    Public SavewordText2 As String
    Public SavewordText3 As String

    'Status to be used with update function for main page
    Public Status1 As Boolean = False
    Public Status2 As Boolean = False
    Public Status3 As Boolean = False
    Public Status4 As Boolean = False
    Public Status5 As Boolean = False

    'Datatable
    Dim table As New DataTable("Table")



    'increment splash screen progress bar function
    Public Sub ConsolSplashIncrement()
        mySplashScreen.Invoke(New MethodInvoker(AddressOf mySplashScreen.IncrementProgress))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim mySplashScreen = DirectCast(My.Application.SplashScreen, Form2)
        'My.Application.mySplashScreen.Invoke(New MethodInvoker(AddressOf My.Application.mySplashScreen.IncrementProgress))


        'Bugfix 1 for metrotab
        Dim speed As Integer = MetroTabControl1.Speed : MetroTabControl1.Speed = 20
        For i As Integer = 0 To MetroTabControl1.TabPages.Count
            MetroTabControl1.SelectedIndex = i
        Next
        MetroTabControl1.SelectedIndex = 0 : MetroTabControl1.Speed = speed

        ConsolSplashIncrement()

        'Moves sidepanel to correct position (because moved out of way for development)
        Sidepanel.Width = 367

        ConsolSplashIncrement()

        'SHOW PRE-RELEASE WARNING
        Panel_PreReleaseWarning.Visible = True

        ConsolSplashIncrement()
        'Highlight first option
        buttontab_1.selected = True

        ConsolSplashIncrement()

        'Initial setup - fills the tables with names (will clear later)
        table.Columns.Add("Id", Type.GetType("System.Int32"))
        ConsolSplashIncrement()
        table.Columns.Add("Value", Type.GetType("System.String"))
        ConsolSplashIncrement()
        table.Columns.Add("Name", Type.GetType("System.String"))
        ConsolSplashIncrement()

        'assinging the datagridview to use 'table' as data source
        DataGridViewVars.DataSource = table
        ConsolSplashIncrement()

        textbox_value_editor.DataBindings.Add("Text", table, "Value")
        ConsolSplashIncrement()

        Me.CenterToScreen()
        ConsolSplashIncrement()

    End Sub

    Private Sub funcdelay100()
        Threading.Thread.Sleep(100)
    End Sub

    'top right exit button
    Private Sub topbarbutton_exit_Click(sender As Object, e As EventArgs) Handles topbarbutton_exit.Click
        Application.Exit()
    End Sub

    'top right minimize button
    Private Sub topbarbutton_min_Click(sender As Object, e As EventArgs) Handles topbarbutton_min.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    'TAB BUTTONS

    'Tab1
    Private Sub buttontab_1_Click(sender As Object, e As EventArgs) Handles buttontab_1.Click

        MetroTabControl1.SelectedTab = Tab1Save

    End Sub
    'Tab2
    Private Sub buttontab_2_Click(sender As Object, e As EventArgs) Handles buttontab_2.Click

        MetroTabControl1.SelectedTab = Tab2Gen

    End Sub
    'Tab3
    Private Sub buttontab_3_Click(sender As Object, e As EventArgs) Handles buttontab_3.Click

        MetroTabControl1.SelectedTab = Tab3Body

    End Sub
    'Tab4
    Private Sub buttontab_4_Click(sender As Object, e As EventArgs) Handles buttontab_4.Click

        MetroTabControl1.SelectedTab = Tab4Infect

    End Sub
    'Tab5 (Not enabled yet)
    Private Sub buttontab_5_Click(sender As Object, e As EventArgs) Handles buttontab_5.Click

        'MetroTabControl1.SelectedTab = Tab5Inv
        MsgBox("Sorry, inventory edits aren't supported yet in this version of FlexEdit.", vbInformation, "FlexEdit")

    End Sub
    'Tab6 (Not enabled yet)
    Private Sub buttontab_6_Click(sender As Object, e As EventArgs) Handles buttontab_6.Click

        'MetroTabControl1.SelectedTab = Tab6Store
        MsgBox("Sorry, storage edits aren't supported yet in this version of FlexEdit.", vbInformation, "FlexEdit")

    End Sub


    'Tab7 (special logic for showing notice prompt)
    Private Sub buttontab_7_Click(sender As Object, e As EventArgs) Handles buttontab_7.Click
        If AcceptedRawTerms = False Then


            Select Case MsgBox("Raw edits is a developer feature only and should not be used without knowledge of the game code. Editing saveword variables can seriously break your story and even Flexible Surival developers cannot fix a badly broken saveword.", MsgBoxStyle.YesNo + vbExclamation, "Are you sure")
                Case MsgBoxResult.Yes
                    AcceptedRawTerms = True
                    MetroTabControl1.SelectedTab = Tab7Raw
            ' Do something if yes
                Case MsgBoxResult.No
                    'do nothing if user does not accept
            End Select

        ElseIf AcceptedRawTerms = True Then
            MetroTabControl1.SelectedTab = Tab7Raw
        End If

    End Sub



    'FUNCTIONS to DISPLAY status of saveword

    Public Sub Status1toLOADED()

        label_status1.Text = "Loaded"

        picbox_status1.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status1toUNLOAD()

        label_status1.Text = "Not loaded"

        picbox_status1.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status2toLOADED()

        label_status2.Text = "Loaded"

        picbox_status2.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status2toUNLOAD()

        label_status2.Text = "Not loaded"

        picbox_status2.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status3toLOADED()

        label_status3.Text = "Loaded"

        picbox_status3.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status3toUNLOAD()

        label_status3.Text = "Not loaded"

        picbox_status3.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status4toLOADED()

        label_status4.Text = "Loaded"

        picbox_status4.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status4toUNLOAD()

        label_status4.Text = "Not loaded"

        picbox_status4.Image = My.Resources.Resources.redfull_error

    End Sub

    Public Sub Status5toLOADED()

        label_status5.Text = "Loaded"

        picbox_status5.Image = My.Resources.Resources.full_success

    End Sub

    Public Sub Status5toUNLOAD()

        label_status5.Text = "Not loaded"

        picbox_status5.Image = My.Resources.Resources.redfull_error

    End Sub

    'Function to set all to unload
    Public Sub StatusCLEAR()

        Status1toUNLOAD()
        Status2toUNLOAD()
        Status3toUNLOAD()
        Status4toUNLOAD()
        Status5toUNLOAD()

    End Sub

    'Function - Checks all vars and updates the labels accordingly
    Public Sub StatusUPDATE()

        If Status1 = True Then
            Status1toLOADED()
        Else
            Status1toUNLOAD()
        End If

        If Status2 = True Then
            Status2toLOADED()
        Else
            Status2toUNLOAD()
        End If

        If Status3 = True Then
            Status3toLOADED()
        Else
            Status3toUNLOAD()
        End If

        If Status4 = True Then
            Status4toLOADED()
        Else
            Status4toUNLOAD()
        End If

        If Status5 = True Then
            Status5toLOADED()
        Else
            Status5toUNLOAD()
        End If

    End Sub

    'FUNCTIONS over

    'Load saveword button
    Private Sub BunifuTileButton3_Click(sender As Object, e As EventArgs) Handles BunifuTileButton3.Click

        Form1.ShowDialog()

    End Sub



    'Load saveword control sub

    Public Sub FUNCSavewordLoadControl()

        Form1.Close()
        'funcdelay100()


        'before doing anything, we assume user is doing this second time.
        'perform cleanup for datatable here
        'Care errors, added error handling as of rev 3
        Try
            table.Clear()
        Catch f As DataException
            ' Process exception below
            MsgBox("Exception of type {0} occurred.",
           f.GetType().ToString())
        End Try



        'after cleanup, repopulate

        '   currently relying on windows logic handling, might add safeguard later

        'ready for normal tasks now


        Dim SaveLoadCompleted1 As Boolean = False
        Dim SaveLoadCompleted2 As Boolean = False
        Dim SaveLoadCompleted3 As Boolean = False

        Try
            Dim rinput As String = SavewordText1
            Dim xValues() As String = rinput.Split("}")
            For count = 0 To xValues.Length - 1
                table.Rows.Add(count + 1, xValues(count))
            Next
            Dim intStr As Integer = xValues(0)
            Dim intDex As Integer = xValues(1)
            Dim intSta As Integer = xValues(2)
            Dim intCha As Integer = xValues(3)
            Dim intPer As Integer = xValues(4)
            Dim intInt As Integer = xValues(5)
            Dim intLvl As Integer = xValues(6)
            Dim intHP As Integer = xValues(7)
            Dim intHum As Integer = xValues(8)
            Dim intScr As Integer = xValues(9)
            'Dim inthpmatt As Integer = xValues(10) 'D
            Dim strBody As String = xValues(11)
            Dim strHead As String = xValues(12)
            Dim strSkin As String = xValues(13)
            Dim strTail As String = xValues(14)
            Dim strGeni As String = xValues(15)
            'vars
            '(not needed) Dim intTanuki As Integer = xValues(16)
            '(not needed) Dim intHosQue As Integer = xValues(17)
            'body
            Dim intbodymod_cocks As Integer = xValues(18)
            Dim intbodymod_breasts As Integer = xValues(19)
            Dim intbodymod_cunts As Integer = xValues(20)
            Dim intbodymod_breast_size As Integer = xValues(21)
            Dim intbodymod_cock_length As Integer = xValues(22)
            Dim intbodymod_cock_width As Integer = xValues(23)
            Dim intbodymod_cunt_length As Integer = xValues(24)
            Dim intbodymod_cunt_width As Integer = xValues(25)
            'wep
            Dim strEqpWeapon As String = xValues(26)
            'vars down below
            '(not needed) Dim intbodymod_cunt_length As Integer = xValues(27)
            '(TEMPLATE) Dim intbodymod_cunt_length As Integer = xValues(28)



            'all vars are filled

            'filling textboxes next for body tab

            nudStr.Text = intStr
            nudDex.Text = intDex
            nudSta.Text = intSta
            nudCha.Text = intCha
            nudPer.Text = intPer
            nudInt.Text = intInt
            nudLvl.Text = intLvl
            nudHP.Text = intHP
            nudHum.Text = intHum
            nudScr.Text = intScr

            'filling infection tab

            comboBODY.Text = strBody
            comboHEAD.Text = strHead
            comboSKIN.Text = strSkin
            comboTAIL.Text = strTail
            comboGENI.Text = strGeni



            'filling ok, variable go

            'body go
            nud_body_cocks.Text = intbodymod_cocks
            nud_body_breasts.Text = intbodymod_breasts
            nud_body_cunts.Text = intbodymod_cunts
            nud_body_breast_size.Text = intbodymod_breast_size
            nud_body_cock_length.Text = intbodymod_cock_length
            nud_body_cock_width.Text = intbodymod_cock_width
            nud_body_cunt_length.Text = intbodymod_cunt_length
            nud_body_cunt_width.Text = intbodymod_cunt_width

            SaveLoadCompleted1 = True


            'error handling
        Catch z As Exception
            MsgBox("Error parsing Saveword Part 1. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

            SaveLoadCompleted2 = False

            MsgBox("Saveword Part 1 has not been loaded. Savewords Part 2 and Part 3 will not be attempted.", vbExclamation, "Caution")


            'disabling tabs and buttons


            Return

        End Try

        'ONLY RUNS FOR SAVEWORD 2
        If saveword2enabled = True Then

            Try
                Dim rinput As String = SavewordText2
                Dim yValues() As String = rinput.Split("}")
                For count = 0 To yValues.Length - 1
                    If count > 0 Then
                        table.Rows.Add(count + 59, yValues(count))
                    End If

                Next 'ends sub here


                SaveLoadCompleted2 = True


                'error handling
            Catch z As Exception
                MsgBox("Error parsing Saveword Part 2. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted2 = False

                MsgBox("Saveword Part 2 has not been loaded. Saveword Part 3 will not be attempted.", vbExclamation, "Caution")

                'disabling tabs and buttons

                Return 'ends sub here
            End Try

        End If

        'Saveword 3 Specific

        If saveword3enabled = True Then

            Try
                Dim rinput As String = SavewordText3
                Dim zValues() As String = rinput.Split("}")
                For count = 0 To zValues.Length - 1
                    If count > 0 Then
                        table.Rows.Add(count + 161, zValues(count))
                    End If

                Next


                SaveLoadCompleted3 = True


                'error handling
            Catch z As Exception

                MsgBox("Error parsing Saveword Part 3. Perhaps you have entered it incorrectly? Exception details: " & z.Message, vbCritical, "Critical Error")

                SaveLoadCompleted3 = False

                MsgBox("Saveword Part 3 has not been loaded.")

                'disabling tabs and buttons

                Return 'ends sub here

            End Try

        End If

        'ENDING SAVEWORD 3

        'determine finishing tasks whether saveword loaded or not
        If SaveLoadCompleted1 = True Then

            MsgBox("Saveword Part 1 import complete!", vbInformation, "Import success")
            Status1 = True

            RunAnnotateVars()


        End If

        'tasks for saveword 2

        If SaveLoadCompleted2 = True AndAlso saveword2enabled = True Then

            MsgBox("Saveword Part 2 import complete!", vbInformation, "Import success")
            Status2 = True

            RunAnnotateVars2()

        End If

        'tasks for saveword 3

        If SaveLoadCompleted3 = True AndAlso saveword3enabled = True Then

            MsgBox("Saveword Part 3 import complete!", vbInformation, "Import success")
            Status3 = True

            RunAnnotateVars3()

        ElseIf SaveLoadCompleted3 = False And saveword3enabled = True Then

            MsgBox("Saveword 3 has not been loaded. Savewords 1 and 2 are loaded normally. You can use the program as is or try loading saveword 3 again.", vbExclamation, "Caution")

        End If

        '(IMPORTANT!!) Updates the labels
        StatusUPDATE()



    End Sub

    'Simple Increment Function

    Private Sub Inc(ByRef i As Integer)
        Try
            i += 1
        Catch z As Exception
            MsgBox("FATAL ERROR Has occured when using the increment function. This should 100% should never ever have happened. Exception details: " & z.Message, vbCritical, "FATAL ERROR")
        End Try
    End Sub

    'Runs update to put textboxes into database (Trigger by button or by export routine)
    Private Sub RunUpdateTextBoxPriority()


        DataGridViewVars.Rows(0).Cells(1).Value = nudStr.Text
        DataGridViewVars.Rows(1).Cells(1).Value = nudDex.Text
        DataGridViewVars.Rows(2).Cells(1).Value = nudSta.Text
        DataGridViewVars.Rows(3).Cells(1).Value = nudCha.Text
        DataGridViewVars.Rows(4).Cells(1).Value = nudPer.Text
        DataGridViewVars.Rows(5).Cells(1).Value = nudInt.Text
        DataGridViewVars.Rows(6).Cells(1).Value = nudLvl.Text
        DataGridViewVars.Rows(7).Cells(1).Value = nudHP.Text
        DataGridViewVars.Rows(8).Cells(1).Value = nudHum.Text
        DataGridViewVars.Rows(9).Cells(1).Value = nudScr.Text

        'filling infection tab

        'Skipped 10 because hp matt not needed

        DataGridViewVars.Rows(11).Cells(1).Value = comboBODY.Text
        DataGridViewVars.Rows(12).Cells(1).Value = comboHEAD.Text
        DataGridViewVars.Rows(13).Cells(1).Value = comboSKIN.Text
        DataGridViewVars.Rows(14).Cells(1).Value = comboTAIL.Text
        DataGridViewVars.Rows(15).Cells(1).Value = comboGENI.Text



        'filling ok, variable go

        'body go

        'Skipped 16,17 because vars (table handling)
        DataGridViewVars.Rows(18).Cells(1).Value = nud_body_cocks.Text
        DataGridViewVars.Rows(19).Cells(1).Value = nud_body_breasts.Text
        DataGridViewVars.Rows(20).Cells(1).Value = nud_body_cunts.Text
        DataGridViewVars.Rows(21).Cells(1).Value = nud_body_breast_size.Text
        DataGridViewVars.Rows(22).Cells(1).Value = nud_body_cock_length.Text
        DataGridViewVars.Rows(23).Cells(1).Value = nud_body_cock_width.Text
        DataGridViewVars.Rows(24).Cells(1).Value = nud_body_cunt_length.Text
        DataGridViewVars.Rows(25).Cells(1).Value = nud_body_cunt_width.Text

    End Sub

    'Annotation Functions
    Private Sub RunAnnotateVars()

        Dim index As Integer = 0

        DataGridViewVars.Rows(index).Cells(2).Value = "Strength"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Dexerity"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Stamina"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Charisma"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Perception"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Intelligence"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Level"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "HP"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Humanity"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Score"
        Inc(index)

        'doctor

        DataGridViewVars.Rows(index).Cells(2).Value = "hp of doctor matt"
        Inc(index)

        'filling infection tab

        DataGridViewVars.Rows(index).Cells(2).Value = "Body infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Head infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Skin infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Tail infection"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Genital infection"
        Inc(index)

        'filling ok, variable go

        DataGridViewVars.Rows(index).Cells(2).Value = "SatisfiedTanuki"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hospquest"
        Inc(index)


        'body go

        DataGridViewVars.Rows(index).Cells(2).Value = "Cocks (Number of cocks)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Breasts (Number of breasts)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunts (Number of cunts)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Breast Size"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cock Length"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cock Width (Also affects cum and ball size)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunt Length"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Cunt Width"
        Inc(index)

        'variables go
        DataGridViewVars.Rows(index).Cells(2).Value = "Equipped Weapon"
        Inc(index)

        'weapon would be index 27
        'more

        DataGridViewVars.Rows(index).Cells(2).Value = "franksex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "frankmalesex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Snow special (annotation)"
        Inc(index) 'hyper squirrel girl thing, will annotate later
        DataGridViewVars.Rows(index).Cells(2).Value = "REMOVED (value always 0)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Coleen special (annotation)"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleentalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenfound"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleencollared"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenalpha"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenslut"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coleenspray"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hp of doctor mouse"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "coonstatus"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "featunlock"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "Butterflymagic? Wth is this?"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "catnum"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mateable"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "gryphoncomforted"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "shiftable"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "medeaget"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mtp"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hyg"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "nes"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mtrp"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "boristalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "borisquest"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "progress of alex"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "angiehappy"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "angietalk"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "deerconsent"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "hp of Susan"
        Inc(index)
        DataGridViewVars.Rows(index).Cells(2).Value = "mattcollection"

    End Sub

    Private Sub RunAnnotateVars2()

        Dim index As Integer = 59 '59 -> 60 - 1 because of 0 start

        DataGridViewVars.Rows(index).Cells(2).Value = "ChantB starts here, not done yet."
        Inc(index)



    End Sub

    Private Sub RunAnnotateVars3()
        'empty
    End Sub

End Class

