# -*- coding: utf-8 -*-

import csv
import re
import sys
"""import locale
try:
    locale.setlocale(locale.LC_ALL, locale="tr_TR")
except locale.Error:
    locale.setlocale(locale.LC_ALL, locale="tr_TR.utf8")"""

#yazma-okuma işlemleri için parametreler
csv.register_dialect('myDialect', delimiter = '|', quoting=csv.QUOTE_NONE, skipinitialspace=True)

def tr_title(param_word):#türkçe harfler için title fonksiyonu
	word_list = param_word.split(sep=" ")
	new_word = ""
	for word in word_list:
		first_letter = word[0]
		last_part = word[1:]

		first_letter = re.sub(r"i", "İ", first_letter)
		first_letter = re.sub(r"ı", "I", first_letter)
		first_letter = re.sub(r"ç", "Ç", first_letter)
		first_letter = re.sub(r"ş", "Ş", first_letter)
		first_letter = re.sub(r"ü", "Ü", first_letter)
		first_letter = re.sub(r"ğ", "Ğ", first_letter)



		last_part = re.sub(r"İ", "i", last_part)
		last_part = re.sub(r"I", "ı", last_part)
		last_part = re.sub(r"Ç", "ç", last_part)
		last_part = re.sub(r"Ş", "ş", last_part)
		last_part = re.sub(r"Ü", "ü", last_part)
		last_part = re.sub(r"Ğ", "ğ", last_part)


		rebuilt_word = first_letter + last_part
		rebuilt_word = rebuilt_word.capitalize()
		new_word = new_word + " " + rebuilt_word


	new_word = new_word.strip()
	return new_word

class Uyeler:
	salonAdi = "Kardeşler Spor Salonu"

	def kayit(Id, adSoyad, yas, boy, kilo, telefon, emailadress, dogumTarihi, program):
		#yeni kayıt için daha öneki üyeler kontrol
		if Uyeler.arama(Id) == None:
			print(f"{Id} numaralı üye oluşturuluyor.")
			return Uyeler(Id, adSoyad, yas, boy, kilo, telefon, emailadress, dogumTarihi, program)
		else:
			print(f"{Id} numaralı üye zaten kayıtlı.")
			return None

	#constructor
	def __init__(self, Id, adSoyad, yas, boy, kilo, telefon, emailadress, dogumTarihi, program):
		self.Id = Id
		self.adSoyad = tr_title(adSoyad)
		#print(adSoyad.title(), type(adSoyad.title()))
		self.yas = yas
		self.boy = boy
		self.kilo = kilo
		self.telefon = telefon #int to str?	#AYB
		self.emailadress = emailadress 		#AYB
		self.dogumTarihi = dogumTarihi
		self.program = program				#AYB

	def serialize(self):#üye bilgilerinin yazıya dökümü
		return [str(self.Id), self.adSoyad, self.yas, self. boy, self.kilo,
				str(self.telefon),self.emailadress,str(self.dogumTarihi),self.program]

	def yazma(self):#bir üyenin dosyaya yazımı
		liste = self.serialize()
		with open("uyeTablo.csv", 'a', encoding = 'utf-8', newline = '') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	def yazmaAhmet(self): 			#AYB
		liste = self.serialize()
		print(liste)

		with open("deneme.csv", 'a', encoding = 'utf-8', newline = '') as writeFile:
			writer = csv.writer(writeFile, 'myDialect')
			writer.writerow(liste)

	def okuma():#üye listesinin okunması
		liste = []
		with open("uyeTablo.csv", 'r', encoding = 'utf-8') as readerFile:
			reader= csv.reader(readerFile, 'myDialect')
			for row in reader:
				liste.append(row)
				#liste.extend(row)
		return liste

	def arama(aranan):#üye arama
		""" csv.register_dialect('myDialect', delimiter = '|', quoting=csv.QUOTE_NONE, skipinitialspace=True)
		with open("uyeTablo.csv", 'r', encoding = 'utf-8') as readerFile:
			reader= csv.reader(readerFile, 'myDialect')
			liste = list(reader) """
		#id(tc kimlik no) veya isim ile arama yapılabilir
		if not(aranan.isalnum() and aranan.istitle()):
			aranan = tr_title(aranan)
		for uye in Uyeler.okuma():
			if aranan in uye:
				return uye
		return None
		#print("Üye bulunamadı!")


uye = []
uye.append(Uyeler.kayit("1", "Yasin Işıktaş", "24", "205", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
uye.append(Uyeler.kayit("2", "Ahmet ikinci", "24", "178", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
uye.append(Uyeler.kayit("3", "ahmet Yusuf", "24", "184", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
uye.append(Uyeler.kayit("4", "rabia ertem", "24", "180", "70", "05394670523", "23pwrpc23@gmail.com", "07.01.1997", "program"))
for i in uye:
	if i != None:
		i.yazma()
#Uyeler.okuma()
#print (locale.getdefaultlocale())
print(Uyeler.arama("rabia ertem"))
#Uyeler()

# def convertToUye(asd):		#AYB
# 	uye = asd.split('|')
# 	return Uyeler(uye[0], uye[1], uye[2], uye[3], uye[4], uye[5], uye[6], uye[7], uye[8])
#
#
# islem = sys.argv[1]			#AYB
# if islem == 'w':				#AYB
# 	a = convertToUye(sys.argv[2]).yazmaAhmet()	#AYB
