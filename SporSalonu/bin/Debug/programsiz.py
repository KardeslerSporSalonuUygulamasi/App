# -*- coding: utf-8 -*-
# from Programs import program as pr
import csv
import re
from Programs import Program as pr
# import os

import sys

# yazma-okuma işlemleri için parametreler
csv.register_dialect("myDialect", delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True, quotechar="")


def tr_title(paramWord: str) -> str:
	"""türkçe harfler için title fonksiyonu"""

	wordList = paramWord.split(sep=" ")
	newWord = ""

	for word in wordList:
		firstLetter = word[0]
		lastPart = word[1:]

		firstLetter = re.sub(r"i", "İ", firstLetter)
		firstLetter = re.sub(r"ı", "I", firstLetter)
		firstLetter = re.sub(r"ç", "Ç", firstLetter)
		firstLetter = re.sub(r"ş", "Ş", firstLetter)
		firstLetter = re.sub(r"ü", "Ü", firstLetter)
		firstLetter = re.sub(r"ğ", "Ğ", firstLetter)

		lastPart = re.sub(r"İ", "i", lastPart)
		lastPart = re.sub(r"I", "ı", lastPart)
		lastPart = re.sub(r"Ç", "ç", lastPart)
		lastPart = re.sub(r"Ş", "ş", lastPart)
		lastPart = re.sub(r"Ü", "ü", lastPart)
		lastPart = re.sub(r"Ğ", "ğ", lastPart)

		rebuiltWord = firstLetter + lastPart
		"""türkçe olmayan harfler için capitalize fonksiyonu"""
		rebuiltWord = rebuiltWord.capitalize()
		newWord = newWord + " " + rebuiltWord

	newWord = newWord.strip()
	return newWord


class BadCommandError(Exception):
	"""Class for BadCommandError"""
	pass


class Uyeler:
	salonAdi = "Kardeşler Spor Salonu"

	# constructor
	def __init__(self, Id: str, ad: str, soyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str, dogumTarihi: str):
		self.Id = Id
		self.ad = tr_title(ad)
		self.soyad = tr_title(soyad)
		# print(adSoyad.title(), type(adSoyad.title()))
		self.yas = yas
		self.cinsiyet = cinsiyet
		self.boy = boy
		self.kilo = kilo
		self.telefon = telefon  # int to str?	#AYB
		self.emailadress = emailadress  # AYB
		self.dogumTarihi = dogumTarihi

	@staticmethod
	def kayit(Id: str, ad: str, soyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str, dogumTarihi: str,) -> object:
		# yeni kayıt için daha önceki üyeler kontrol
		if Uyeler.arama(Id) is None:
			print(f"{Id} numaralı üye oluşturuluyor.")
			return Uyeler(Id, ad, soyad, yas, cinsiyet, boy, kilo, telefon, emailadress, dogumTarihi)
		else:
			print(f"{Id} numaralı üye zaten kayıtlı.")
			return None

	def serialize(self) -> list:  # üye bilgilerinin yazıya dökümü
		return [str(self.Id), self.ad, self.soyad, self.yas, self.cinsiyet, self.boy, self.kilo,
				str(self.telefon), self.emailadress, str(self.dogumTarihi)]

	def yazma(self):  # bir üyenin bilgilerinin dosyaya yazımı
		liste = self.serialize()
		with open("uyeTablo.csv", mode='a', encoding="utf-8", newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	def yazmaAhmet(self):  # AYB
		liste = self.serialize()
		print(liste)

		with open("uyeTablo.csv", mode='a', encoding="utf-8", newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	@staticmethod
	def okuma() -> list:  # üye listesinin okunması #filenotfound except edildi
		liste = []
		try:
			with open("uyeTablo.csv", mode='r', encoding="utf-8") as readerFile:
				reader = csv.reader(readerFile, 'myDialect')
				for row in reader:
					liste.append(row)

		except FileNotFoundError:
			file = open("uyeTablo.csv", mode='w', encoding="utf-8")
			file.close()

		finally:
			return liste

	@staticmethod
	def arama(aranan: str):  # TODO: sadece isimle arama yapılırsa aranan ot of index veriyor
		# id(tc kimlik no) veya isim ile arama yapılabilir
		arananL = []
		if not (aranan.isalnum() and aranan.istitle()):
			aranan = tr_title(aranan)
			temp = aranan.split(" ")
			arananL.append(' '.join(temp[0:-1]))
			arananL.append(temp[-1])

		for uye in Uyeler.okuma():
			if (arananL[0] in uye) or (arananL[1] in uye):
				return uye
		return None

	@staticmethod
	def silme(silinecekUye: str, command: str):
		"""Üye silmek için method"""
		ind = None  # dosyanın sırasını bozmamak için indis değeri
		liste = Uyeler.okuma()

		if command == "sil":
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					liste.pop(ind)
					with open("uyeTablo.csv", mode='w', encoding="utf-8", newline='') as writeFile:
						writer = csv.writer(writeFile, 'myDialect')
						writer.writerows(liste)
					print("Üye başarıyla silinmiştir.")
					break

		elif command == "update":  # TODO: Yusuftaki dosyayı düzenle
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					liste.pop(ind)
					return ind, liste
			return None
		else:
			raise BadCommandError("Bad command: %s" %command)

	@staticmethod
	def guncelleme(guncelUye: list):  # TODO: tc numarasını değiştirince
		"""Üye güncellemek için method"""
		indis, liste = Uyeler.silme(str(guncelUye[0]), "update")
		if indis is not None:
			# * opertörüyle indis indis yazmadan constructor çalışır mı???
			yeniUye = Uyeler(guncelUye[0], guncelUye[1], guncelUye[2], guncelUye[3], guncelUye[4], guncelUye[5],
			                 guncelUye[6], guncelUye[7], guncelUye[8], guncelUye[9])
			if yeniUye is not None:
				liste.insert(indis, yeniUye.serialize())

			# IDEA dosyayı baştan yazmak yerine yeni dosya oluşturmayı da deneyebilirsin
			print(liste)
			with open("uyeTablo.csv", mode='w', encoding="utf-8", newline='') as writeFile:
				writer = csv.writer(writeFile, 'myDialect')
				writer.writerows(liste)
			print("Üye başarıyla güncellenmiştir.")

		else:
			return f"Böyle bir üye yok!"




def convertToUye(asd):		#AYB
	uye = asd.split('|')
	return Uyeler.kayit(uye[0], uye[1], uye[2], uye[3], uye[4], uye[5], uye[6], uye[7], uye[8], uye[9])

def convertToUyeUp(asd):	#AYB
	uye = asd.split('|')
	return uye

def convertFromUye(uye):	#AYB
	return f"{uye[0]}|{uye[1]}|{uye[2]}|{uye[3]}|{uye[4]}|{uye[5]}|{uye[6]}|{uye[7]}|{uye[8]}|{uye[9]}"

def replaceProgram(program):
	program = program.replace(';', ' ')
	program = program.replace('*', '\n')
	print('python ', program)
	return program

islem = sys.argv[1]			#AYB
if islem == 'w':			#AYB
	a = convertToUye(sys.argv[2]).yazmaAhmet()	#AYB

elif islem == 'r':
	#print(sys.argv[2])
	#aa = "Ahmet İkinci"
	a = Uyeler.arama(sys.argv[2])
	print(convertFromUye(a))

elif islem == 'g':
	a = convertToUye(sys.argv[2]).guncelleme()
	a = Uyeler.guncelleme(convertToUyeUp(sys.argv[2]))

elif islem == 'pw':
	print(sys.argv[3])
	pr.programYaz(replaceProgram(sys.argv[3]), sys.argv[2])


# pr.programYaz("asdjkfhaljksdhfgasdfg", "37684252692")
# print(pr.programOku("37684252692"))




	"""@property
	def Id(self):
		return self.Id"""

	"""@Id.setter
	def Id(self, Id):
		# TODO: encapsulation yapılacak
		#if Id.isdecimal():
		self.Id = Id"""


"""uye = []
uye.append(Uyeler.kayit("1", "Yasin", "Işıktaş", "24", "Erkek", "205", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997",))
if uye[0] is not None:
	uye[0].yazma()
	

uye.append(
	Uyeler.kayit("2", "Ahmet", "ikinci", "24", "Erkek", "178", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997"))
if uye[1] is not None:
	uye[1].yazma()
uye.append(
	Uyeler.kayit("3", "ahmet Yusuf", "birinci", "24", "Erkek", "184", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997"))
if uye[2] is not None:
	uye[2].yazma()
uye.append(
	Uyeler.kayit("4", "rabia", "ertem", "24", "Kadın", "180", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997",))
if uye[3] is not None:
	uye[3].yazma()

#print(f"str: {uye[0]}")# TODO: __repr__ ve __str__ yazılacak

Uyeler.guncelleme(["2", "Ahmet", "ikinci", "22", "ERkek", "183", "85", "05394670523", "23pwrpc23@gmail.com", "27.07.1999"])"""





#Uyeler.arama("Ahmet Yusuf")

#Uyeler.silme("2", "sil")

# Uyeler.okuma()
# print (locale.getdefaultlocale())
""" print(Uyeler.arama("rabia ertem"))
print(pr.yagsizKiloHesapla(1,180, 70))
print(pr.kaloriYakmaHesapla(1, 60))
print((pr.boyKiloendeks(170,70)))
print((pr.netyaghesaplama(1,70,180))) """

# Uyeler()

