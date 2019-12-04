#pragma once

#include "BrowserWindow.h"
using namespace System;

namespace TestBrowserWindowWrapper
{
	public ref class BrowserWindowWrapper
	{
		public:
		BrowserWindow *myBrowserWindow;	
	
		BrowserWindowWrapper() : myBrowserWindow(new BrowserWindow()) 
		{
		}
	};

}