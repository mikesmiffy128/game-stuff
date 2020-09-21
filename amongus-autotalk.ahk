; This file is dedicated to the public domain.

#IfWinActive ahk_class UnityWndClass

; hardcoded detection pixels based on my 1080p screen, making some attempt to
; scale to other screens...
; XXX scaling might affect colours in which case you'll need to mess with this
; on a different res! not my problem :-)
; - the grey frame of the vote menu (sample either side to avoid fluke pixels)
frameleft_x := 220 * A_ScreenWidth / 1920
frameleft_y := 120 * A_ScreenHeight / 1080
frameright_x := 1620 * A_ScreenWidth / 1920
frameright_y := 340 * A_ScreenHeight / 1080
framecolour := 0x8F97A4
; - part of the screen crack when you're dead
; (high up so dead chat doesn't cover it)
crack_x = 408 * A_ScreenWidth / 1920
crack_y = 85 * A_ScreenHeight / 1080
crackcolour := 0x232B2F

cantalk := 0

Loop {
	PixelGetColor, frameleft, frameleft_x, frameleft_y, RGB
	PixelGetColor, frameright, frameright_x, frameright_y, RGB
	PixelGetColor, crack, crack_x, crack_y, RGB

	; thanks ahk for making me write this stupid long line and failing to parse
	; if I try to split it up :)
	if (frameleft == framecolour && frameright == framecolour && crack != crackcolour) {
		; thanks ahk for also making me write stupid crap like this too
		; god dammit
		if (!cantalk) {
			Send {RCtrl down}
		}
		cantalk := 1
	}
	else {
		if (cantalk) {
			Send {RCtrl up}
		}
		cantalk := 0
	}
	Sleep, 100
}
