#!/usr/bin/env python
# coding: utf-8


import pymongo
import datetime


def _main():

	client = pymongo.MongoClient('localhost', 27017)
	db = client['test']
	collection = db['sakaguradb']

	# removes one.
	collection.delete_one({'HAUSYQHDB': 'AIUEO'})
	# truncates.
	collection.delete_many({})
	# create document.
	collection.insert_one({
		u'会社名': u'那賀酒造有限会社',
		u'住所': u'徳島県那賀郡那賀町和食字町35',
		u'電話': u'0884-62-2003',
		u'銘柄': [u'旭若松 純米 無濾過生原酒 山田錦',
					u'旭若松 純米 無濾過生原酒 雄町'],
		u'time': datetime.datetime.now()
	})

_main()

