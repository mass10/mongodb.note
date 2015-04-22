#!/usr/bin/env python
# coding: utf-8


import sys
import pymongo
import json
import codecs

#def Print(*args):
#	out = codecs.getwriter('utf-8')(sys.stdout)
#	for e in args:
#		out.write(e)
#	out.write("\n")

def Main():

	print '### 開始 ###'

	client = pymongo.MongoClient('localhost', 27017, )
	db = client['test']
	collection = db['sakaguradb']
	for e in collection.find():
		e['_id'] = "..."
		# del e['_id']
		print json.dumps(e, ensure_ascii=False, sort_keys=True, indent=4)

	print '--- end ---'

Main()

