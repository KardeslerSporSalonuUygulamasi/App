# -*- coding: utf-8 -*-
# from Programs import program as pr
import csv
import re
import sys
# import os

# import sys

# yazma-okuma işlemleri için parametreler
csv.register_dialect("myDialect", delimiter='|', quoting=csv.QUOTE_NONE, skipinitialspace=True)


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

	@staticmethod
	def kayit(Id: str, adSoyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str, dogumTarihi: str,
			  program: str) -> object:
		# yeni kayıt için daha önceki üyeler kontrol
		if Uyeler.arama(Id) is None:
			print(f"{Id} numaralı üye oluşturuluyor.")
			return Uyeler(Id, adSoyad, yas, cinsiyet, boy, kilo, telefon, emailadress, dogumTarihi, program)
		else:
			print(f"{Id} numaralı üye zaten kayıtlı.")
			return None

	# constructor
	def __init__(self, Id: str, adSoyad: str, yas: str, cinsiyet: str, boy: str, kilo: str, telefon: str, emailadress: str,
				 dogumTarihi: str, program: str):
		self.Id = Id
		self.adSoyad = tr_title(adSoyad)
		# print(adSoyad.title(), type(adSoyad.title()))
		self.yas = yas
		self.cinsiyet = cinsiyet
		self.boy = boy
		self.kilo = kilo
		self.telefon = telefon  # int to str?	#AYB
		self.emailadress = emailadress  # AYB
		self.dogumTarihi = dogumTarihi
		self.program = program  # AYB

	def serialize(self) -> list:  # üye bilgilerinin yazıya dökümü
		return [str(self.Id), self.adSoyad, self.yas, self.cinsiyet ,self.boy, self.kilo,
				str(self.telefon), self.emailadress, str(self.dogumTarihi), self.program]

	def yazma(self):  # bir üyenin bilgilerinin dosyaya yazımı
		liste = self.serialize()
		with open("deneme.csv", mode='a', encoding="utf-8", newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	def yazmaAhmet(self):  # AYB
		liste = self.serialize()
		print(liste)

		with open("deneme.csv", mode='a', encoding="utf-8", newline='') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	@staticmethod
	def okuma() -> list:  # üye listesinin okunması #filenotfound except edildi
		liste = []
		#print("okunan: ", liste)##debug
		try:
			with open("deneme.csv", mode='r', encoding="utf-8") as readerFile:
				reader = csv.reader(readerFile, 'myDialect')
				for row in reader:
					liste.append(row)
		# liste.extend(row)
		# print("okunan: ", liste)

		except FileNotFoundError:
			file = open("deneme.csv", mode='w', encoding="utf-8")
			file.close()

		finally:
			return liste

	@staticmethod
	def arama(aranan: str):
		# üye arama ## sadece isimle(soyad olmadan) arama için güncelleme yapılabilir #dönüş tipinden emin değilim
		""" csv.register_dialect('myDialect', delimiter = '|', quoting=csv.QUOTE_NONE, skipinitialspace=True)
		with open("uyeTablo.csv", mode='r', encoding = 'utf-8') as readerFile:
			reader= csv.reader(readerFile, 'myDialect')
			liste = list(reader) """
		# id(tc kimlik no) veya isim ile arama yapılabilir
		# TODO aranan değişkenine tekrar atama yapılıyor
		if not (aranan.isalnum() and aranan.istitle()):
			aranan = tr_title(aranan)

		for uye in Uyeler.okuma():
			if aranan in uye:
				return uye
		return None

	# print("Üye bulunamadı!")

	@staticmethod
	def silme(silinecekUye: str, command: str):
		"""Üye silmek için method"""
		ind = None  # dosyanın sırasını bozmamak için indis değeri
		liste = Uyeler.okuma()

		if command == "sil":
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					# print("id uye: ", id(uye), "id liste: ", id(liste[1]))##debug
					del liste[ind]
					# liste.pop(ind)
					# print("id uye: ", id(uye), "id liste: ", id(liste[1]))
					with open("deneme.csv", mode='w', encoding="utf-8", newline='') as writeFile:
						writer = csv.writer(writeFile, 'myDialect')
						writer.writerows(liste)
					break

		elif command == "update":
			for ind, uye in enumerate(liste):
				if silinecekUye in uye:
					# del liste[ind]
					liste.pop(ind)
					with open("deneme.csv", mode='w', encoding="utf-8", newline='') as writeFile:
						writer = csv.writer(writeFile, 'myDialect')
						writer.writerows(liste)
					return ind, liste
			return None
		else:
			raise BadCommandError("Bad command: %s" %command)

	@staticmethod
	def guncelleme(guncelUye: list):
		"""Üye güncellemek için method"""
		indis, liste = Uyeler.silme(str(guncelUye[0]), "update")
		if indis is not None:
			# * opertörüyle indis indis yazmadan constructor çalışır mı???
			yeniUye = Uyeler(guncelUye[0], guncelUye[1], guncelUye[2], guncelUye[3], guncelUye[4], guncelUye[5],
			                 guncelUye[6], guncelUye[7], guncelUye[8])
			if yeniUye is not None:
				liste.insert(indis, yeniUye.serialize())

			# IDEA dosyayı baştan yazmak yerine yeni dosya oluşturmayı da deneyebilirsin
			with open("deneme.csv", mode='w', encoding="utf-8", newline='') as writeFile:
				writer = csv.writer(writeFile, 'myDialect')
				writer.writerows(liste)

		else:
			return f"Böyle bir üye yok!"





# uye = []
# uye.append(Uyeler.kayit("1", "Yasin Işıktaş", "24", "205", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997",
#                         "program"))
# if uye[0] is not None:
# 	uye[0].yazma()
# uye.append(
# 	Uyeler.kayit("2", "Ahmet ikinci", "24", "178", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
# if uye[1] is not None:
# 	uye[1].yazma()
# uye.append(
# 	Uyeler.kayit("3", "ahmet Yusuf birinci", "24", "184", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997",
# 	             "program"))
# if uye[2] is not None:
# 	uye[2].yazma()
# uye.append(
# 	Uyeler.kayit("4", "rabia ertem", "24", "180", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
# if uye[3] is not None:
# 	uye[3].yazma()

# Uyeler.guncelleme('2', ["2", "Ahmet ikinci", "22", "183", "85", "05394670523", "23pwrpc23@gmail.com", "27.07.1999",
#                         "proGram"])

# Uyeler.okuma()
# print (locale.getdefaultlocale())
""" print(Uyeler.arama("rabia ertem"))
print(pr.yagsizKiloHesapla(1,180, 70))
print(pr.kaloriYakmaHesapla(1, 60))
print((pr.boyKiloendeks(170,70)))
print((pr.netyaghesaplama(1,70,180))) """

# Uyeler()

# def convertToUye(asd):		#AYB
# 	uye = asd.split('|')
# 	return Uyeler(uye[0], uye[1], uye[2], uye[3], uye[4], uye[5], uye[6], uye[7], uye[8])
#
#
# islem = sys.argv[1]			#AYB
# if islem == 'w':				#AYB
# 	a = convertToUye(sys.argv[2]).yazmaAhmet()	#AYB



def convertToUye(asd):		#AYB
	uye = asd.split('|')
	return Uyeler.kayit(uye[0], uye[1], uye[2], uye[3], uye[4], uye[5], uye[6], uye[7], uye[8], uye[9])

def convertToUye2(asd):		#AYB
	uye = asd.split('|')
	return uye

def convertFromUye(uye):	#AYB
	return f'"{uye[0]}|{uye[1]}|{uye[2]}|{uye[3]}|{uye[4]}|{uye[5]}|{uye[6]}|{uye[7]}|{uye[8]}|{uye[9]}"'

islem = sys.argv[1]			#AYB
if islem == 'w':			#AYB
	a = convertToUye(sys.argv[2]).yazmaAhmet()	#AYB
elif islem == 'r':
	#print(sys.argv[2])
	#aa = "Ahmet İkinci"
	a = Uyeler.arama(sys.argv[2])
	print(convertFromUye(a))
elif islem == 'g':
	#a = convertToUye(sys.argv[2]).guncelleme()
	a = Uyeler.guncelleme(convertToUye2(sys.argv[2]))
elif islem == 's':
	a = Uyeler.silme(sys.argv[2], "sil")